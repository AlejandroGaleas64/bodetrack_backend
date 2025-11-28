using AutoMapper;
using BodeTrack.API.Helpers;
using BodeTrack.BusinnesLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace BodeTrack.API.Controllers.General
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class MunicipiosController : Controller
    {
        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;

        public MunicipiosController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("ListarPorDepartamento/{deptCodigo}")]
        public IActionResult ListarPorDepartamento(string deptCodigo)
        {
            var result = _generalServices.ListarMunicipiosPorDepartamento(deptCodigo);
            return StatusCode(result.Code, result);
        }
    }
}