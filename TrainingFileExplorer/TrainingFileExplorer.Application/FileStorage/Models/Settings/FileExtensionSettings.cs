using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Application.FileStorage.Models.Filtering;

namespace TrainingFileExplorer.Application.FileStorage.Models.Settings
{
    public class FileExtensionSettings
    {
        public StorageFileType FileType { get; set; }

        public string DisplayName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<string> Extensions { get; set; } = default!;
    }
}
