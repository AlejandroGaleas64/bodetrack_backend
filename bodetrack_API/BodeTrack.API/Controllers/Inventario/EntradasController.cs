using AutoMapper;
using BodeTrack.API.Helpers;
using BodeTrack.API.Models.Inventario;
using BodeTrack.BusinnesLogic.Services;
using BodeTrack.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BodeTrack.API.Controllers.Inventario
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class EntradasController : Controller
    {
        private readonly InventarioServices _inventarioServices;
        private readonly IMapper _mapper;

        public EntradasController(InventarioServices inventarioServices, IMapper mapper)
        {
            _inventarioServices = inventarioServices;
            _mapper = mapper;
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] EntradaInsertarViewModel model)
        {
            var entrada = _mapper.Map<tbEntradas>(model);
            var result = _inventarioServices.InsertarEntrada(entrada, model.Detalles.Cast<object>().ToList());

            return StatusCode(result.Code, result);
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var result = _inventarioServices.ListarEntradas();
            return StatusCode(result.Code, result);
        }
    }
}