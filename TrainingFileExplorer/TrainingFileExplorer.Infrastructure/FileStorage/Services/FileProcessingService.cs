using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.Common.Models.Filtering;
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

        public async ValueTask<IList<StorageFile>> GetByFilterAsync(StorageFileFilterModel filterModel)
        {
            var filteredFilesPath = _directoryService
                .GetFilesPath(filterModel.DirectoryPath, filterModel)
                .Where(filePath => filterModel.FileTypes.Contains(_fileService.GetFileType(filePath)));
        }

        public async ValueTask<StorageFileFilterDataModel> GetFilterDataModelAsync(string directoryPath)
        {
            var pagination = new FilterPagination
            {
                PageSize = int.MaxValue,
                PageToken = 1
            };

            var filesPath = _directoryService.GetFilesPath(directoryPath, pagination);
            var files = 
        }
    }
}
