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
    public class DirectoryBroker : IDirectoryBroker
    {
        private readonly IMapper _mapper;

        public DirectoryBroker(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool ExistsAsync(string directoryPath) => Directory.Exists(directoryPath);

        public StorageDirectory GetByPathAsync(string directoriesPath) => _mapper.Map<StorageDirectory>(new DirectoryInfo(directoriesPath));

        public IEnumerable<StorageDirectory> GetDirectories(string directoryPath) => GetDirectoriesPath(directoryPath)
            .Select(path => _mapper.Map<StorageDirectory>(new DirectoryInfo(path)));

        public IEnumerable<string> GetDirectoriesPath(string directoryPath) => Directory.EnumerateDirectories(directoryPath);
     
        public IEnumerable<string> GetFilesPath(string directoryPath) => Directory.EnumerateFiles(directoryPath);
    }
}
