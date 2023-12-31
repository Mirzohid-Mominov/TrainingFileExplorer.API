﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFileExplorer.Application.FileStorage.Models.Storage
{
    public class StorageDirectory : IStorageEntry
    {
        public string Name { get; set; } = string.Empty;

        public string Path { get; set; } = string.Empty;

        public long ItemsCount { get; set; }

        public StorageEntryType EntryType { get; set; } = StorageEntryType.Directory;
    }
}
