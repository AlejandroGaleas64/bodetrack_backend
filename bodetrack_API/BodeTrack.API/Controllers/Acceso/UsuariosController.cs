using AutoMapper;
using BodeTrack.API.Helpers;
using BodeTrack.API.Models.Acceso;
using BodeTrack.BusinnesLogic.Services;
using BodeTrack.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BodeTrack.API.Controllers.Acceso
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class UsuariosController : Controller
    {
        private readonly AccesoServices _accesoServices;
        private readonly IMapper _mapper;

        public UsuariosController(AccesoServices accesoServices, IMapper mapper)
        {
            _accesoServices = accesoServices;
            _mapper = mapper;
        }

        [HttpPost("IniciarSesion")]
        public IActionResult IniciarSesion([FromBody] UsuariosViewModel item)
        {
            var mapped = _mapper.Map<tbUsuarios>(item);
            var result = _accesoServices.IniciarSesion(mapped);

            // Mapear ServiceResult.Code a HTTP status codes
            return StatusCode(result.Code, result);
        }
    }
}