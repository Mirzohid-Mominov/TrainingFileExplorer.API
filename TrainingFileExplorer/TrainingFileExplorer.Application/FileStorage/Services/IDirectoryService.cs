using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.Common.Models.Filtering;
using TrainingFileExplorer.Application.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Application.FileStorage.Services;

public interface IDirectoryService
{
    IEnumerable<string> GetDirectoriesPath(string dorectoryPath, FilterPagination paginationOptions);

    IEnumerable<string> GetFilesPath(string directoryPath,  FilterPagination paginationOptions);

    ValueTask<IList<StorageDirectory>> GetDirectoriesAsync(string directoryPath, FilterPagination paginationOptions);

    ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath);
}
