using AutoMapper;
using BodeTrack.API.Helpers;
using BodeTrack.BusinnesLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace BodeTrack.API.Controllers.General
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class ArticulosController : Controller
    {
        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;

        public ArticulosController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var result = _generalServices.ListarArticulos();
            return StatusCode(result.Code, result);
        }

        [HttpGet("ListarConDetalle")]
        public IActionResult ListarConDetalle()
        {
            var result = _generalServices.ListarArticulosConDetalle();
            return StatusCode(result.Code, result);
        }
    }
}