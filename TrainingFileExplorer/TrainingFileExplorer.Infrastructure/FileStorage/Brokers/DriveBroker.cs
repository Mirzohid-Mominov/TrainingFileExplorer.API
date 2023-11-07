using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.FileStorage.Brokers;
using TrainingFileExplorer.Application.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Infrastructure.FileStorage.Brokers
{
    public class DriveBroker : IDriveBroker
    {
        private readonly IMapper _mapper;

        public DriveBroker(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<StorageDrive> Get()
        {
            return DriveInfo
                .GetDrives()
                .Select(drive => _mapper.Map<StorageDrive>(drive))
                .AsQueryable();
        }
    }
}
