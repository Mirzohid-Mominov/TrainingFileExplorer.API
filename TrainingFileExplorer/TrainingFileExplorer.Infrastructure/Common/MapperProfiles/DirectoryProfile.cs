﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingFileExplorer.Application.FileStorage.Models.Storage;

namespace TrainingFileExplorer.Infrastructure.Common.MapperProfiles
{
    public class DirectoryProfile : Profile
    {
        public DirectoryProfile()
        {
            CreateMap<DirectoryInfo, StorageDirectory>()
                .ForMember(src => src.Name, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(src => src.Path, opt => opt.MapFrom(dest => dest.FullName))
                .ForMember(src => src.ItemsCount, opt => opt.MapFrom(dest => dest.GetFileSystemInfos().Count()));
        }
    }
}
