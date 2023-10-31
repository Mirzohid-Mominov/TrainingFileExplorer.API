using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.FileStorage.Brokers;
using TrainingFileExplorer.Aplication.FileStorage.Models.Filtering;
using TrainingFileExplorer.Aplication.FileStorage.Models.Settings;
using TrainingFileExplorer.Aplication.FileStorage.Models.Storage;
using TrainingFileExplorer.Aplication.FileStorage.Services;

namespace TrainingFileExplorer.Infrastructure.FileStorage.Services
{
    public class FileService : IFileService
    {
        private readonly FileFilterSettings _filterSettings;
        private readonly IFileBroker _broker;

        public FileService(IFileBroker broker, IOptions<FileFilterSettings> fileFilterSettings)
        {
            _filterSettings = fileFilterSettings.Value;
            _broker = broker;
        }

        public ValueTask<StorageFile> GetFileByPathAsync(string filePath) =>
            !string.IsNullOrWhiteSpace(filePath)
                ? new ValueTask<StorageFile>(_broker.GetByPath(filePath))
                : throw new ArgumentNullException(nameof(filePath));

        public async ValueTask<IList<StorageFile>> GetFilesByPathAsync(IEnumerable<string> filesPath)
        {
            var files = await Task.Run(() =>
            {
                return filesPath.Select(filePath => _broker.GetByPath(filePath)).ToList();
            });

            return files;
        }

        public StorageFileType GetFileType(string filePath)
        {
            var fileExtension = Path.GetExtension(filePath).TrimStart('.');
            var matchedFileType = _filterSettings.FileExtensions.FirstOrDefault(extension => extension.Extensions.Contains(fileExtension));

            return matchedFileType?.FileType ?? StorageFileType.Other;
        }
    }
}
