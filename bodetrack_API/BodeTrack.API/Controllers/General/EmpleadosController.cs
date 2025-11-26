using AutoMapper;
using BodeTrack.API.Helpers;
using BodeTrack.BusinnesLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace BodeTrack.API.Controllers.General
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class EmpleadosController : Controller
    {
        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;

        public EmpleadosController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var result = _generalServices.ListarEmpleados();
            return StatusCode(result.Code, result);
        }
    }
}
