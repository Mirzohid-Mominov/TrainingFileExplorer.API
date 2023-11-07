using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Application.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Infrastructure.Common.MapperProfiles
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<FileInfo, StorageFile>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.DirectoryPath, opt => opt.MapFrom(src => src.DirectoryName))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Length))
                .ForMember(dest => dest.Extension, opt => opt.MapFrom(src => src.Extension));
        }
    }
}
