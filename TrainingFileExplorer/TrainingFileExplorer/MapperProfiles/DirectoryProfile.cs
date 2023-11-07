using AutoMapper;
using Training.FileExplorer.Api.Models.Dtos;
using TrainingFileExplorer.Application.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Api.MapperProfiles
{
    public class DirectoryProfile : Profile
    {
        public DirectoryProfile()
        {
            CreateMap<StorageDirectory, StorageDirectoryDto>();
            CreateMap<StorageDirectoryDto, StorageDirectory>();
        }

    }
}
