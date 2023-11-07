using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Aplication.Common.Models.Filtering;

namespace TrainingFileExplorer.Aplication.FileStorage.Models.Filtering;

public class StorageFileFilterDataModel
{
    public List<StorageFilesSummary> FilterData { get; set; } = new();
}
