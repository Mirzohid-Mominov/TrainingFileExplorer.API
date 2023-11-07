

using TrainingFileExplorer.Application.FileStorage.Models.Storage;

namespace Training.FileExplorer.Api.Models.Dtos;

public interface IStorageItemDto
{
    string Path { get; set; }

    StorageEntryType EntryType { get; set; }
}