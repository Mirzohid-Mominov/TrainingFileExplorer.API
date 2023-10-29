using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Aplication.FileStorage.Services
{
    public interface IDirectoryService
    {
        IEnumerable<string> GetDirectoriesPath(string directoriesPath);
        IEnumerable<string> GetFilesPath(string directoriesPath);
        ValueTask<IList<StorageDirectory>> GetDirectoriesAsync(string directoriesPath); 
        ValueTask<StorageDirectory?>  GetByPathAsync(string directoriesPath);
    }
}
