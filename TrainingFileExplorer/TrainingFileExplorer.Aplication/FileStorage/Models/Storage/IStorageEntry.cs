using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFileExplorer.Aplication.FileStorage.Models.Storage
{
    public interface IStorageEntry
    {
        string Name { get; set; }    
        StorageEntryType EntryType { get; set; }
    }
}
