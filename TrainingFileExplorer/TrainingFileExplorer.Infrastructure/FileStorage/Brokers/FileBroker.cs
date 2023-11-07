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
    public class FileBroker : IFileBroker
    {
        private readonly IMapper _mapper;

        public FileBroker(IMapper mapper)
        {
            _mapper = mapper;
        }

        public StorageFile GetByPath(string filePath)
        {
            return _mapper.Map<StorageFile>(new FileInfo(filePath));
        }
    }
}
