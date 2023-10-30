using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFileExplorer.Aplication.FileStorage.Models.Storage
{
    public class StorageDrive : IStorageEntry
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public StorageEntryType EntryType { get; set; } = StorageEntryType.Drive;
    }
}
