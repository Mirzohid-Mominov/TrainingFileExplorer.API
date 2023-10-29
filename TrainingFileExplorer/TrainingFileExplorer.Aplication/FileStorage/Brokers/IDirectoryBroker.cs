using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Aplication.FileStorage.Brokers
{
    public interface IDirectoryBroker
    {
        IEnumerable<string> GetDirectoriesPath(string directoriesPath);
        IEnumerable<string> GetFilesPath(string directoriesPath);
        IEnumerable<StorageDirectory> GetDirectoriesAsync(string directoriesPath);
        StorageDirectory GetByPathAsync(string directoriesPath);
        bool ExistsAsync(string directoriesPath);
    }
}
