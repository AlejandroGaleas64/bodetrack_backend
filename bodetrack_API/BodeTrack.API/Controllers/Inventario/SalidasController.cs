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

        [HttpPut("ActualizarGuia/{saliId}")]
        public async Task<IActionResult> SubirGuiaRemision(int saliId, IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                return BadRequest(new { success = false, message = "Archivo no proporcionado." });
            }

            // Validar extensión
            var extension = Path.GetExtension(archivo.FileName).ToLowerInvariant();
            if (extension != ".pdf")
            {
                return BadRequest(new { success = false, message = "Solo se permiten archivos PDF." });
            }

            // Leer el archivo como byte[]
            using var memoryStream = new MemoryStream();
            await archivo.CopyToAsync(memoryStream);
            byte[] pdfBytes = memoryStream.ToArray();

            var result = _inventarioServices.ActualizarGuiaRemision(saliId, pdfBytes);
            return StatusCode(result.Code, result);
        }

        [HttpGet("DescargarGuia/{saliId}")]
        public IActionResult DescargarGuiaRemision(int saliId)
        {
            var result = _inventarioServices.ObtenerGuiaRemision(saliId);

            if (!result.Success)
            {
                return StatusCode(result.Code, result);
            }

            var pdfBytes = (byte[])result.Data;

            if (pdfBytes == null || pdfBytes.Length == 0)
            {
                return NotFound(new { message = "No hay guía de remisión para esta salida." });
            }

            return File(pdfBytes, "application/pdf", $"guia_salida_{saliId}.pdf");
        }
    }
}