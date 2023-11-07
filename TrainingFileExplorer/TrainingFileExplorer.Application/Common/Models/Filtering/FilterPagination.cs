using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrainingFileExplorer.Aplication.Common.Models.Filtering
{
    public class FilterPagination
    {
        public uint PageSize { get; set; } = 10;
        
        public uint PageToken { get; set; } = 1;
    }
}
