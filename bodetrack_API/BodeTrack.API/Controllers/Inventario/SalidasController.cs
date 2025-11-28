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
    public class SalidasController : Controller
    {
        private readonly InventarioServices _inventarioServices;
        private readonly IMapper _mapper;

        public SalidasController(InventarioServices inventarioServices, IMapper mapper)
        {
            _inventarioServices = inventarioServices;
            _mapper = mapper;
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] SalidaInsertarViewModel model)
        {
            var salida = _mapper.Map<tbSalidas>(model);
            var result = _inventarioServices.InsertarSalida(salida, model.Detalles.Cast<object>().ToList());

            return StatusCode(result.Code, result);
        }

        [HttpPut("Recibir")]
        public IActionResult Recibir([FromBody] RecibirSalidaViewModel model)
        {
            var result = _inventarioServices.RecibirSalida(model.Sali_Id, model.Usua_Creacion);
            return StatusCode(result.Code, result);
        }

        [HttpGet("ObtenerCompleta/{saliId}")]
        public IActionResult ObtenerCompleta(int saliId)
        {
            var result = _inventarioServices.ObtenerSalidaCompleta(saliId);
            return StatusCode(result.Code, result);
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var result = _inventarioServices.ListarSalidas();
            return StatusCode(result.Code, result);
        }
    }
}
