using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFileExplorer.Aplication.FileStorage.Models.Filtering
{
    public class StorageFileFilterModel
    {
        public string DirectoryPath { get; set; } = string.Empty;
        public ICollection<StorageFileType> FileTypes { get; set; } = default;
    }
}
