using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Aplication.FileStorage.Services
{
    public interface IDriveService
    {
        ValueTask<IList<StorageDrive>> GetAsync();
    }
}
