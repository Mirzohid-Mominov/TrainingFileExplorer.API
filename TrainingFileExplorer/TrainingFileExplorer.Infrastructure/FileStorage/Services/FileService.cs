using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.FileStorage.Brokers;
using TrainingFileExplorer.Aplication.FileStorage.Models.Filtering;
using TrainingFileExplorer.Aplication.FileStorage.Models.Storage;
using TrainingFileExplorer.Aplication.FileStorage.Services;

namespace TrainingFileExplorer.Infrastructure.FileStorage.Services
{
    public class FileService : IFileService
    {
        private readonly IFileBroker _broker;

        public FileService(IFileBroker broker)
        {
            _broker = broker;
        }

        public ValueTask<StorageFile> GetFileByPathAsync(string filePath) =>
            !string.IsNullOrWhiteSpace(filePath)
                ? new ValueTask<StorageFile>(_broker.GetByPath(filePath))
                : throw new ArgumentNullException(nameof(filePath));

        public async ValueTask<IList<StorageFile>> GetFilesByPathAsync(IEnumerable<string> filesPath)
        {
            var files = await Task.Run(() =>
            {
                return filesPath.Select(filePath => _broker.GetByPath(filePath)).ToList();
            });

            return files;
        }
    }
}
