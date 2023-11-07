using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Application.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Aplication.FileStorage.Brokers
{
    public interface IDirectoryBroker
    {
        IEnumerable<string> GetDirectoriesPath(string directoryPath);

        IEnumerable<string> GetFilesPath(string directoryPath);

        IEnumerable<StorageDirectory> GetDirectories(string directoryPath);

        StorageDirectory GetByPathAsync(string directoriesPath);

        bool ExistsAsync(string directoryPath);
    }
}
