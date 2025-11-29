using BodeTrack.DataAccess.Repositories.Inventario;
using BodeTrack.Entities.Entities;
using System.Text.Json;

namespace BodeTrack.BusinnesLogic.Services
{
    public class InventarioServices
    {
        private readonly EntradasRepository _entradasRepository;
        private readonly LotesRepository _lotesRepository;
        private readonly SalidasRepository _salidaRepository;

        public InventarioServices(
            EntradasRepository entradasRepository,
            LotesRepository lotesRepository,
            SalidasRepository salidaRepository
            )
        {
            _entradasRepository = entradasRepository;
            _lotesRepository = lotesRepository;
            _salidaRepository = salidaRepository;
        }

        #region Entradas

        public ServiceResult InsertarEntrada(tbEntradas entrada, List<object> detalles)
        {
            var result = new ServiceResult();

            try
            {
                // Validaciones de entrada
                if (string.IsNullOrWhiteSpace(entrada.Entr_NumeroFactura))
                {
                    return result.BadRequest("El número de factura es requerido.");
                }

                if (entrada.Entr_Creacion <= 0)
                {
                    return result.BadRequest("El ID de usuario creador es obligatorio.");
                }

                if (detalles == null || !detalles.Any())
                {
                    return result.BadRequest("Debe especificar al menos un artículo en la entrada.");
                }

                // Serializar los detalles a JSON
                var jsonDetalles = JsonSerializer.Serialize(detalles, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null
                });

                // Llamar al repositorio
                var response = _entradasRepository.InsertarEntrada(entrada, jsonDetalles);

                // Verificar respuesta del SP
                if (response == null)
                {
                    return result.Error("Error al procesar la entrada de inventario.");
                }

                if (response.code_Status == -1)
                {
                    return result.BadRequest(response.message_Status ?? "Error en la validación de datos.");
                }

                if (response.code_Status == 0)
                {
                    return result.Error(response.message_Status ?? "Error interno al registrar la entrada.");
                }

                // code_Status == 1: Éxito
                return result.Ok(response.message_Status);
            }
            catch (JsonException ex)
            {
                return result.Error(
                    message: "Error al procesar los detalles de la entrada.",
                    data: new { Error = ex.Message }
                );
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                return result.Error(
                    message: "Error al consultar la base de datos.",
                    data: new { Error = ex.Message }
                );
            }
            catch (Exception ex)
            {
                return result.Error(
                    message: "Ocurrió un error inesperado al registrar la entrada.",
                    data: new { Error = ex.Message }
                );
            }
        }

        public ServiceResult ListarEntradas()
        {
            var result = new ServiceResult();

            try
            {
                var list = _entradasRepository.List();

                if (list == null || !list.Any())
                {
                    return result.NotFound("No se encontraron entradas.");
                }

                return result.Ok(list);
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                return result.Error(
                    message: "Error al consultar la base de datos.",
                    data: new { Error = ex.Message }
                );
            }
            catch (Exception ex)
            {
                return result.Error(
                    message: "Ocurrió un error inesperado al listar entradas.",
                    data: new { Error = ex.Message }
                );
            }
        }

        #endregion Entradas

        #region Lotes

        public ServiceResult ListarLotes()
        {
            var result = new ServiceResult();

            try
            {
                var list = _lotesRepository.List();

                if (list == null || !list.Any())
                {
                    return result.NotFound("No se encontraron lotes.");
                }

                return result.Ok(list);
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                return result.Error(
                    message: "Error al consultar la base de datos.",
                    data: new { Error = ex.Message }
                );
            }
            catch (Exception ex)
            {
                return result.Error(
                    message: "Ocurrió un error inesperado al listar lotes.",
                    data: new { Error = ex.Message }
                );
            }
        }

        #endregion Lotes

        #region Salidas

        public ServiceResult InsertarSalida(tbSalidas salida, List<object> detalles)
        {
            var result = new ServiceResult();

            try
            {
                // Validaciones de entrada
                if (salida.Sucs_Id <= 0)
                {
                    return result.BadRequest("El ID de sucursal es requerido.");
                }

                if (salida.Sali_UsuarioEnvia <= 0)
                {
                    return result.BadRequest("El ID de usuario que envía es requerido.");
                }

                if (salida.Sali_Creacion <= 0)
                {
                    return result.BadRequest("El ID de usuario creador es obligatorio.");
                }

                if (detalles == null || !detalles.Any())
                {
                    return result.BadRequest("Debe especificar al menos un artículo en la salida.");
                }

                // Serializar los detalles a JSON
                var jsonDetalles = JsonSerializer.Serialize(detalles, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null
                });

                // Llamar al repositorio
                var response = _salidaRepository.InsertarSalida(salida, jsonDetalles);

                // Verificar respuesta del SP
                if (response == null)
                {
                    return result.Error("Error al procesar la salida de inventario.");
                }

                if (response.code_Status == -1)
                {
                    // Errores de validación (permisos, stock, límites, etc.)
                    return result.BadRequest(response.message_Status ?? "Error en la validación de datos.");
                }

                if (response.code_Status == 0)
                {
                    return result.Error(response.message_Status ?? "Error interno al registrar la salida.");
                }

                // code_Status == 1: Éxito
                return result.Ok(response.message_Status);
            }
            catch (JsonException ex)
            {
                return result.Error(
                    message: "Error al procesar los detalles de la salida.",
                    data: new { Error = ex.Message }
                );
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                return result.Error(
                    message: "Error al consultar la base de datos.",
                    data: new { Error = ex.Message }
                );
            }
            catch (Exception ex)
            {
                return result.Error(
                    message: "Ocurrió un error inesperado al registrar la salida.",
                    data: new { Error = ex.Message }
                );
            }
        }

        public ServiceResult ObtenerSalidaCompleta(int sali_Id)
        {
            var result = new ServiceResult();

            try
            {
                if (sali_Id <= 0)
                {
                    return result.BadRequest("El ID de salida debe ser mayor a 0.");
                }

                var response = _salidaRepository.ObtenerSalidaCompleta(sali_Id);

                if (response == null)
                {
                    return result.Error("Error al consultar la salida.");
                }

                // Verificar Code_Status del SP
                if (response.Code_Status == 0)
                {
                    return result.NotFound(response.Message_Status ?? "La salida no existe o está inactiva.");
                }

                // Code_Status == 1: Éxito
                return result.Ok(response);
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                return result.Error(
                    message: "Error al consultar la base de datos.",
                    data: new { Error = ex.Message }
                );
            }
            catch (Exception ex)
            {
                return result.Error(
                    message: "Ocurrió un error inesperado al obtener la salida.",
                    data: new { Error = ex.Message }
                );
            }
        }

        public ServiceResult RecibirSalida(int sali_Id, int usuarioRecibeId)
        {
            var result = new ServiceResult();

            try
            {
                if (sali_Id <= 0)
                {
                    return result.BadRequest("El ID de salida debe ser mayor a 0.");
                }

                if (usuarioRecibeId <= 0)
                {
                    return result.BadRequest("El ID de usuario que recibe es obligatorio.");
                }

                var response = _salidaRepository.RecibirSalida(sali_Id, usuarioRecibeId);

                if (response == null)
                {
                    return result.Error("Error al procesar la recepción de la salida.");
                }

                if (response.code_Status == 0)
                {
                    return result.BadRequest(response.message_Status ?? "Error al recibir la salida.");
                }

                // code_Status == 1: Éxito
                return result.Ok(response.message_Status);
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                return result.Error(
                    message: "Error al consultar la base de datos.",
                    data: new { Error = ex.Message }
                );
            }
            catch (Exception ex)
            {
                return result.Error(
                    message: "Ocurrió un error inesperado al recibir la salida.",
                    data: new { Error = ex.Message }
                );
            }
        }

        public ServiceResult ListarSalidas()
        {
            var result = new ServiceResult();

            try
            {
                var list = _salidaRepository.List();

                if (list == null || !list.Any())
                {
                    return result.NotFound("No se encontraron salidas.");
                }

                return result.Ok(list);
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                return result.Error(
                    message: "Error al consultar la base de datos.",
                    data: new { Error = ex.Message }
                );
            }
            catch (Exception ex)
            {
                return result.Error(
                    message: "Ocurrió un error inesperado al listar salidas.",
                    data: new { Error = ex.Message }
                );
            }
        }

        public ServiceResult ActualizarGuiaRemision(int sali_Id, byte[] pdfBytes)
        {
            var result = new ServiceResult();
            try
            {
                if (sali_Id <= 0)
                {
                    return result.BadRequest("El ID de salida debe ser mayor a 0.");
                }
                if (pdfBytes == null || pdfBytes.Length == 0)
                {
                    return result.BadRequest("El archivo PDF es requerido.");
                }
                // Validar tamaño máximo (10 MB)
                const int maxSize = 10 * 1024 * 1024; // 10 MB
                if (pdfBytes.Length > maxSize)
                {
                    return result.BadRequest($"El archivo excede el tamaño máximo permitido de 10 MB. Tamaño actual: {pdfBytes.Length / 1024 / 1024} MB");
                }
                // Validar que sea un PDF (magic bytes)
                if (!IsPdf(pdfBytes))
                {
                    return result.BadRequest("El archivo debe ser un PDF válido.");
                }
                var response = _salidaRepository.ActualizarGuiaRemision(sali_Id, pdfBytes);
                if (response == null || response.code_Status == 0)
                {
                    return result.Error("No se pudo actualizar la guía de remisión.");
                }
                return result.Ok("Guía de remisión actualizada exitosamente.");
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                return result.Error(
                    message: "Error al consultar la base de datos.",
                    data: new { Error = ex.Message }
                );
            }
            catch (Exception ex)
            {
                return result.Error(
                    message: "Ocurrió un error inesperado al actualizar la guía.",
                    data: new { Error = ex.Message }
                );
            }
        }

        public ServiceResult ObtenerGuiaRemision(int sali_Id)
        {
            var result = new ServiceResult();
            try
            {
                if (sali_Id <= 0)
                {
                    return result.BadRequest("El ID de salida debe ser mayor a 0.");
                }
                var pdfBytes = _salidaRepository.ObtenerGuiaRemision(sali_Id);
                if (pdfBytes == null || pdfBytes.Length == 0)
                {
                    return result.NotFound("No se encontró la guía de remisión para esta salida.");
                }
                return result.Ok(pdfBytes);
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                return result.Error(
                    message: "Error al consultar la base de datos.",
                    data: new { Error = ex.Message }
                );
            }
            catch (Exception ex)
            {
                return result.Error(
                    message: "Ocurrió un error inesperado al obtener la guía.",
                    data: new { Error = ex.Message }
                );
            }
        }

        private bool IsPdf(byte[] bytes)
        {
            // PDF magic bytes: %PDF
            if (bytes.Length < 4) return false;
            return bytes[0] == 0x25 && bytes[1] == 0x50 && bytes[2] == 0x44 && bytes[3] == 0x46;
        }

        #endregion Salidas
    }
}