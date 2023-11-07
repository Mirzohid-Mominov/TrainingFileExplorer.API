using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFileExplorer.Application.FileStorage.Models.Settings
{
    public class FileFilterSettings
    {
        public ICollection<FileExtensionSettings> FileExtensions { get; set; } = default!;
    }
}
