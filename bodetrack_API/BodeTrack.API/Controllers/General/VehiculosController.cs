using AutoMapper;
using BodeTrack.API.Helpers;
using BodeTrack.BusinnesLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace BodeTrack.API.Controllers.General
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class VehiculosController : Controller
    {
        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;

        public VehiculosController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var result = _generalServices.ListarVehiculos();
            return StatusCode(result.Code, result);
        }
    }
}
