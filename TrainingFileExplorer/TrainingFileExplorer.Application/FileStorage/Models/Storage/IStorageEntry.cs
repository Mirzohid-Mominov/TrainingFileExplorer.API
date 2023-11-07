using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFileExplorer.Application.FileStorage.Models.Storage;

public interface IStorageEntry
{
    string Path { get; set; }

    StorageEntryType EntryType { get; set; }
}
