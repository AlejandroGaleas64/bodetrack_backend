using AutoMapper;
using BodeTrack.API.Models.General;
using BodeTrack.Entities.Entities;

namespace BodeTrack.API.Extensions
{
    public class MappingProfileExtensions : Profile
    {
        public MappingProfileExtensions()
        {
            CreateMap<tbDepartamentos, DepartamentosViewModel>().ReverseMap();
        }
    }
}