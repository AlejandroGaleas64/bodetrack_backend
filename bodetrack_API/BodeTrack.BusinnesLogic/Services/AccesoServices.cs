using BodeTrack.DataAccess.Repositories.Acceso;
using BodeTrack.Entities.Entities;

namespace BodeTrack.BusinnesLogic.Services
{
    public class AccesoServices
    {
        private readonly UsuariosRepository _usuarioRepository;

        public AccesoServices(UsuariosRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public ServiceResult IniciarSesion(tbUsuarios item)
        {
            var result = new ServiceResult();

            try
            {
                // Validaciones básicas de entrada
                if (string.IsNullOrWhiteSpace(item.Usua_NombreUsuario))
                {
                    return result.BadRequest("El nombre de usuario es requerido.");
                }

                if (string.IsNullOrWhiteSpace(item.Usua_Clave))
                {
                    return result.BadRequest("La contraseña es requerida.");
                }

                var response = _usuarioRepository.Login(item);

                // El SP retorna null si hay error o credenciales incorrectas
                if (response == null)
                {
                    return result.Error("Error al procesar el inicio de sesión.");
                }

                // Verificar el Code_Status retornado por el SP
                if (response.Code_Status == -1)
                {
                    return result.Unauthorized(response.Message_Status ?? "Usuario o contraseña incorrectos.");
                }

                if (response.Code_Status == 0)
                {
                    return result.Error(response.Message_Status ?? "Error al procesar el inicio de sesión.");
                }

                // Code_Status == 1: Login exitoso
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
                    message: "Ocurrió un error inesperado al iniciar sesión.",
                    data: new { Error = ex.Message }
                );
            }
        }
    }
}