using AutoMapper;
using Training.FileExplorer.Api.Models.Dtos;
using TrainingFileExplorer.Application.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Api.MapperProfiles
{
    public class DriveProfile : Profile
    {
        public DriveProfile()
        {
            CreateMap<StorageDriveDto, StorageDrive>();
            CreateMap<StorageDrive, StorageDriveDto>();
        }
    }
}
