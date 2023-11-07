using AutoMapper;
using Training.FileExplorer.Api.Models.Dtos;
using TrainingFileExplorer.Application.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Api.MapperProfiles
{
    public class StorageItemProfile : Profile
    {
        public StorageItemProfile()
        {
            CreateMap<IStorageEntry, IStorageItemDto>();
            CreateMap<IStorageItemDto, IStorageEntry>();
        }
    }
}
