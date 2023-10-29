using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.FileStorage.Brokers;
using TrainingFileExplorer.Aplication.FileStorage.Models.Storage;
using TrainingFileExplorer.Aplication.FileStorage.Services;

namespace TrainingFileExplorer.Infrastructure.FileStorage.Services
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IDirectoryBroker _broker;
        private readonly IMapper _mapper;
        public DirectoryService(IDirectoryBroker broker, IMapper mapper)
        {
            _broker = broker;
            _mapper = mapper;
        }

        public ValueTask<StorageDirectory?> GetByPathAsync(string directoriesPath)
        {
            if(string.IsNullOrWhiteSpace(directoriesPath))
                throw new ArgumentNullException(nameof(directoriesPath));
            return new(_broker.GetByPathAsync(directoriesPath));
        }
       
        public async ValueTask<IList<StorageDirectory>> GetDirectoriesAsync(string directoriesPath)
        {
            if(string.IsNullOrWhiteSpace(directoriesPath))
                throw new ArgumentNullException(nameof(directoriesPath));

            var diretories = await Task.Run(() =>  _broker.GetDirectoriesAsync(directoriesPath).ToList());
            return diretories;
        }

        public IEnumerable<string> GetDirectoriesPath(string directoriesPath) =>
            _broker.GetFilesPath(directoriesPath);
       
        public IEnumerable<string> GetFilesPath(string directoriesPath) =>
            _broker.GetFilesPath(directoriesPath);
        
    }
}
