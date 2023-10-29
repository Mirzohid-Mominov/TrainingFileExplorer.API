using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.FileStorage.Models.Storage;
using TrainingFileExplorer.Aplication.FileStorage.Services;

namespace TrainingFileExplorer.Infrastructure.FileStorage.Services
{
    public class DirectoryProcessingService : IDirectoryProcessingService
    {
        private readonly IFileService _fileService;
        private readonly IDirectoryService _directoryService;
        public DirectoryProcessingService(IFileService fileService, IDirectoryService directoryService)
        {
            _directoryService = directoryService;
            _fileService = fileService;
        }

        public async ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPath)
        {
            var storageItems = new List<IStorageEntry>();

            storageItems.AddRange(await _directoryService.GetDirectoriesAsync(directoryPath));

            storageItems.AddRange(await _fileService.GetFilesByPathAsync(_directoryService.GetFilesPath(directoryPath)));

            return storageItems;
        }
    }
}
