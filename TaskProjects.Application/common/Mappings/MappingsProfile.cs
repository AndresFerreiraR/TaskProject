using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TaskProjects.Commons.Dto;
using TaskProjects.Domain.Entities;

namespace TaskProjects.Application.common.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
        }
    }
}