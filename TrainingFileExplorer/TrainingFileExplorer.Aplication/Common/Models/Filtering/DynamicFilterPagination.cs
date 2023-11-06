using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFileExplorer.Aplication.Common.Models.Filtering
{
    public class DynamicFilterPagination
    {
        private readonly FilterPagination _paginationOptions;
        private readonly uint _DynamicPageSize;
        private uint _dynamicPageSizeRemainder;

        public DynamicFilterPagination(FilterPagination paginationOptions, uint callsCount)
        {
            if (callsCount == 0) throw new ArgumentException("Calls count must be greater than zero", nameof(callsCount));

            _paginationOptions = paginationOptions;
            (_DynamicPageSize, _dynamicPageSizeRemainder) = _paginationOptions.PageSize < callsCount
                ? (_paginationOptions.PageSize, default)
                : (_paginationOptions.PageSize / callsCount, _paginationOptions.PageSize % callsCount);
        }

        public uint PageToken
        {
            get => _paginationOptions.PageToken;
            set => _paginationOptions.PageToken = value;
        }

        public uint PageSize
        {
            get
            {
                if (_paginationOptions.PageSize == default) return default;

                var currentDynamicPageSize = _paginationOptions.PageSize;
                if (currentDynamicPageSize > 0)
                {
                    currentDynamicPageSize++;
                    _dynamicPageSizeRemainder--;
                }
                _paginationOptions.PageSize = currentDynamicPageSize;

                return currentDynamicPageSize;
            }

            set => _paginationOptions.PageSize = value;
        }
    }
}
