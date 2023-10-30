using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.FileStorage.Models.Filtering;

namespace TrainingFileExplorer.Aplication.FileStorage.Models.Settings
{
    public class FileExtensionSettings
    {
        public StorageFileType FileType { get; set; }

        public string DisplayName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<string> Extensions { get; set; } = default!;
    }
}
