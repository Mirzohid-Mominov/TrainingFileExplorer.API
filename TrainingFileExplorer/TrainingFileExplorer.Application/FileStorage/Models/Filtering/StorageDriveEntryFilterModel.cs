using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.Common.Models.Filtering;

namespace TrainingFileExplorer.Aplication.FileStorage.Models.Filtering
{
    public class StorageDriveEntryFilterModel : FilterPagination
    {
        public bool IncludeDirectories { get; set; }

        public bool IncludeFiles { get; set; }
    }
}
