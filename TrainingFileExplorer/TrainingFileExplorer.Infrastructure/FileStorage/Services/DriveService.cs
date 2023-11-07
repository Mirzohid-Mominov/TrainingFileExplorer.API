using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.FileStorage.Brokers;
using TrainingFileExplorer.Application.FileStorage.Models.Storage;
using TrainingFileExplorer.Application.FileStorage.Services;

namespace TrainingFileExplorer.Infrastructure.FileStorage.Services
{
    public class DriveService : IDriveService
    {
        private readonly IDriveBroker _driveBroker;
        public DriveService(IDriveBroker driveBroker)
        {
            _driveBroker = driveBroker;
        }

        public ValueTask<IList<StorageDrive>> GetAsync()
        {
            var drives = _driveBroker.Get().ToList();

            return new ValueTask<IList<StorageDrive>>(drives);
        }
    }
}
