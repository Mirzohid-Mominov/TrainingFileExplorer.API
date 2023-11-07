using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.Common.Models.Filtering;
using TrainingFileExplorer.Application.FileStorage.Models.Filtering;
using TrainingFileExplorer.Application.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Application.FileStorage.Services;

public interface IFileService
{
    ValueTask<IList<StorageFile>> GetFilesByPathAsync(IEnumerable<string> filesPath);

    ValueTask<StorageFile> GetFileByPathAsync(string filePath);

    IEnumerable<StorageFilesSummary> GetFilesSummary(IEnumerable<StorageFile> files);

    StorageFileType GetFileType(string filePath);
}
