using AutoMapper;
using System.Security.Cryptography.X509Certificates;
using Training.FileExplorer.Api.Models.Dtos;
using TrainingFileExplorer.Application.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Api.MapperProfiles
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<StorageFileDto, StorageFile>();
            CreateMap<StorageFile, StorageFileDto>();
        }
    }
}
