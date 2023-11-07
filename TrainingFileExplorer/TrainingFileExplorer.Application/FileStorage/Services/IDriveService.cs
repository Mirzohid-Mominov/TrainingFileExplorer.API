using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Application.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Application.FileStorage.Services;

public interface IDriveService
{
    ValueTask<IList<StorageDrive>> GetAsync();
}
