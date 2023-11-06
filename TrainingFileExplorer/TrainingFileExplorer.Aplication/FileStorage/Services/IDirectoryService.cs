using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.Common.Models.Filtering;
using TrainingFileExplorer.Aplication.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Aplication.FileStorage.Services
{
    public interface IDirectoryService
    {
        IEnumerable<string> GetDirectoriesPath(string directoriesPath, FilterPagination paginationOptions);
        IEnumerable<string> GetFilesPath(string directoriesPath, FilterPagination paginationOptions);
        ValueTask<IList<StorageDirectory>> GetDirectoriesAsync(string directoriesPath, FilterPagination paginationOptions); 
        ValueTask<StorageDirectory?>  GetByPathAsync(string directoriesPath);
    }
}
