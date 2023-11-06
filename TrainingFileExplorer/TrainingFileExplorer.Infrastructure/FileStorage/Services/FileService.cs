using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.Common.Models.Filtering;
using TrainingFileExplorer.Aplication.FileStorage.Brokers;
using TrainingFileExplorer.Aplication.FileStorage.Models.Filtering;
using TrainingFileExplorer.Aplication.FileStorage.Models.Settings;
using TrainingFileExplorer.Aplication.FileStorage.Models.Storage;
using TrainingFileExplorer.Aplication.FileStorage.Services;
using TrainingFileExplorer.Infrastructure.FileStorage.Brokers;

namespace TrainingFileExplorer.Infrastructure.FileStorage.Services;

public class FileService : IFileService
{
    private readonly FileFilterSettings _filterSettings;
    private readonly FileStorageSettings _storageSettings;
    private readonly IFileBroker _broker;

    public FileService(IFileBroker broker, IOptions<FileFilterSettings> fileFilterSettings, IOptions<FileStorageSettings> storageSettings)
    {
        _filterSettings = fileFilterSettings.Value;
        _storageSettings = storageSettings.Value;
        _broker = broker;
    }

    public ValueTask<StorageFile> GetFileByPathAsync(string filePath) =>
        !string.IsNullOrWhiteSpace(filePath)
            ? new ValueTask<StorageFile>(_broker.GetByPath(filePath))
            : throw new ArgumentNullException(nameof(filePath));

    public async ValueTask<IList<StorageFile>> GetFilesByPathAsync(IEnumerable<string> filesPath)
    {
        var files = await Task.Run(() => { return filesPath.Select(filePath => _broker.GetByPath(filePath)).ToList(); });

        return files;
    }

    public IEnumerable<StorageFilesSummary> GetFilesSummary(IEnumerable<StorageFile> files)
    {
        var filesType = files.Select(file => (File: file, Type: GetFileType(file.Path)));
        return filesType
            .GroupBy(file => file.Type)
            .Select(filesGroup => new StorageFilesSummary
            {
                FileType = filesGroup.Key,
                DisplayName = _filterSettings.FileExtensions.FirstOrDefault(extension => extension.FileType == filesGroup.Key)?.DisplayName ??
                              "Other files",
                Count = filesGroup.Count(),
                Size = filesGroup.Sum(file => file.File.Size),
                ImageUrl = _filterSettings.FileExtensions.FirstOrDefault(extension => extension.FileType == filesGroup.Key)?.ImageUrl ??
                           _storageSettings.FileImageUrl
            });
    }

    public StorageFileType GetFileType(string filePath)
    {
        var fileExtension = Path.GetExtension(filePath).TrimStart('.');
        var matchedFileType = _filterSettings.FileExtensions.FirstOrDefault(extension => extension.Extensions.Contains(fileExtension));
        return matchedFileType?.FileType ?? StorageFileType.Other;
    }
}
