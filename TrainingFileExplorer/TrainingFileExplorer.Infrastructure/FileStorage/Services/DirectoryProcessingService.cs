using TrainingFileExplorer.Aplication.FileStorage.Models.Filtering;
using TrainingFileExplorer.Application.FileStorage.Models.Storage;
using TrainingFileExplorer.Application.FileStorage.Services;

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

        public async ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPath, StorageDirectoryEntryFilterModel filterModel)
        {
            var storageItems = new List<IStorageEntry>();

            // filterModel.SetDynamicPagination(2);

            if (filterModel.IncludeDirectories)
                storageItems.AddRange(await _directoryService.GetDirectoriesAsync(directoryPath, filterModel));

            if (filterModel.IncludeFiles)
                storageItems.AddRange(await _fileService.GetFilesByPathAsync(_directoryService.GetFilesPath(directoryPath, filterModel)));

            return storageItems;
        }
    }
}
