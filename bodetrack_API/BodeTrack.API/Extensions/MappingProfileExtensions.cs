using AutoMapper;
using BodeTrack.API.Models.General;
using BodeTrack.API.Models.Acceso;
using BodeTrack.API.Models.Inventario;
using BodeTrack.Entities.Entities;

namespace BodeTrack.API.Extensions
{
    public class MappingProfileExtensions : Profile
    {
        public MappingProfileExtensions()
        {
            CreateMap<tbArticulos, ArticulosViewModel>().ReverseMap();
            CreateMap<tbCargos, CargosViewModel>().ReverseMap();
            CreateMap<tbDepartamentos, DepartamentosViewModel>().ReverseMap();
            CreateMap<tbEmpleados, EmpleadosViewModel>().ReverseMap();
            CreateMap<tbEntradas, EntradaInsertarViewModel>().ReverseMap();
            CreateMap<tbEstadosCiviles, EstadosCivilesViewModel>().ReverseMap();
            CreateMap<tbLotes, LotesViewModel>().ReverseMap();
            CreateMap<tbMunicipios, MunicipiosViewModel>().ReverseMap();
            CreateMap<tbSalidas, SalidaInsertarViewModel>().ReverseMap();
            CreateMap<tbSucursales, SucursalesViewModel>().ReverseMap();
            CreateMap<tbUsuarios, UsuariosViewModel>().ReverseMap();
            CreateMap<tbVehiculos, VehiculosViewModel>().ReverseMap();
        }
    }
}