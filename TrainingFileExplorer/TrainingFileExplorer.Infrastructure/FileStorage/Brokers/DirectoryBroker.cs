using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.FileStorage.Brokers;
using TrainingFileExplorer.Aplication.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Infrastructure.FileStorage.Brokers
{
    public class DirectoryBroker : IDirectoryBroker
    {
        private readonly IMapper _mapper;

        public DirectoryBroker(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        public IEnumerable<string> GetDirectoriesPath(string directoriesPath) => Directory.EnumerateDirectories(directoriesPath);
        
        public IEnumerable<string> GetFilesPath(string directoriesPath) => Directory.EnumerateFiles(directoriesPath);
        
        public IEnumerable<StorageDirectory> GetDirectoriesAsync(string directoriesPath) => GetDirectoriesPath(directoriesPath)
            .Select(path => _mapper.Map<StorageDirectory>(new DirectoryInfo(path)));
        
        public StorageDirectory GetByPathAsync(string directoriesPath) => _mapper.Map<StorageDirectory>(new DirectoryInfo(directoriesPath));

        public bool ExistsAsync(string directoriesPath) => Directory.Exists(directoriesPath);
    }
}
