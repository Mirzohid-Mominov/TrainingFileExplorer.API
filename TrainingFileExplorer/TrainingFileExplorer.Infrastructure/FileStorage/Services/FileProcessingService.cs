using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.FileStorage.Models.Filtering;
using TrainingFileExplorer.Aplication.FileStorage.Models.Storage;
using TrainingFileExplorer.Aplication.FileStorage.Services;

namespace TrainingFileExplorer.Infrastructure.FileStorage.Services
{
    public class FileProcessingService : IFileProcessingService
    {
        private readonly IDirectoryService _directoryService;
        private readonly IFileService _fileService;

        public FileProcessingService(IDirectoryService directoryService, IFileService fileService)
        {
            _directoryService = directoryService;
            _fileService = fileService;
        }

        public async ValueTask<IList<StorageFile>> GetFilterAsync(StorageFileFilterModel filterModel)
        {
            var filteredFilesPath = _directoryService
                .GetFilesPath(filterModel.DirectoryPath)
                .Where(filesPath => filterModel.FileTypes.Contains(_fileService.GetFileType(filesPath)));

            var files = await _fileService.GetFilesByPathAsync(filteredFilesPath);

            return files;
        }

    }
}
