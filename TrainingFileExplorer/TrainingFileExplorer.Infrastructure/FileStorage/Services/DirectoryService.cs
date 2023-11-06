using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.Common.Models.Filtering;
using TrainingFileExplorer.Aplication.Common.Querying.Extensions;
using TrainingFileExplorer.Aplication.FileStorage.Brokers;
using TrainingFileExplorer.Aplication.FileStorage.Models.Storage;
using TrainingFileExplorer.Aplication.FileStorage.Services;

namespace TrainingFileExplorer.Infrastructure.FileStorage.Services;

public class DirectoryService : IDirectoryService
{
    private readonly IDirectoryBroker _broker;
    private readonly IMapper _mapper;
    public DirectoryService(IDirectoryBroker broker, IMapper mapper)
    {
        _broker = broker;
        _mapper = mapper;
    }
    public IEnumerable<string> GetDirectoriesPath(string directoryPath, FilterPagination paginationOptions) =>
        _broker.GetFilesPath(directoryPath).ApplyPagination(paginationOptions);

    public IEnumerable<string> GetFilesPath(string directoryPath, FilterPagination paginationOptions) =>
        _broker.GetFilesPath(directoryPath).ApplyPagination(paginationOptions);

    public ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        return new ValueTask<StorageDirectory?>(_broker.GetByPathAsync(directoryPath));
    }

    public async ValueTask<IList<StorageDirectory>> GetDirectoriesAsync(string directoryPath, FilterPagination paginationOptions)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        var directories = await Task.Run(() => _broker.GetDirectories(directoryPath).ApplyPagination(paginationOptions).ToList());

        return directories;
    }
}
