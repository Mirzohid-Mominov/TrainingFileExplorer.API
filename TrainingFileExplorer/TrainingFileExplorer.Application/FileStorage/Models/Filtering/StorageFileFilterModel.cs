using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.Common.Models.Filtering;

namespace TrainingFileExplorer.Application.FileStorage.Models.Filtering
{
    public class StorageFileFilterModel : FilterPagination
    {
        public string DirectoryPath { get; set; } = string.Empty;

        public ICollection<StorageFileType> FileTypes { get; set; } = default!;
    }
}
