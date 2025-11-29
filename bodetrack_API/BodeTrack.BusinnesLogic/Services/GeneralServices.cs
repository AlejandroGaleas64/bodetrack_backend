using BodeTrack.DataAccess.Repositories.General;

namespace BodeTrack.BusinnesLogic.Services
{
    public class GeneralServices
    {
        private readonly ArticulosRepository _articuloRepository;
        private readonly CargosRepository _cargoRepository;
        private readonly DepartamentosRepository _departamentoRepository;
        private readonly EmpleadosRepository _empleadoRepository;
        private readonly EstadosCivilesRespository _estadoCivilRepository;
        private readonly MunicipiosRepository _municipioRepository;
        private readonly SucursalesRepository _sucursalRepository;
        private readonly VehiculosRepository _vehiculoRepository;

        public GeneralServices(
            ArticulosRepository articuloRepository,
            CargosRepository cargoRepository,
            DepartamentosRepository departamentoRepository,
            EmpleadosRepository empleadoRepository,
            EstadosCivilesRespository estadoCivilRepository,
            MunicipiosRepository municipioRepository,
            SucursalesRepository sucursalRepository,
            VehiculosRepository vehiculoRepository
            )
        {
            _articuloRepository = articuloRepository;
            _cargoRepository = cargoRepository;
            _departamentoRepository = departamentoRepository;
            _empleadoRepository = empleadoRepository;
            _estadoCivilRepository = estadoCivilRepository;
            _municipioRepository = municipioRepository;
            _sucursalRepository = sucursalRepository;
            _vehiculoRepository = vehiculoRepository;
        }

        #region Articulos

        public ServiceResult ListarArticulos()
        {
            var result = new ServiceResult();

            try
            {
                var list = _articuloRepository.List();

                if (list == null || !list.Any())
                {
                    return result.NotFound("No se encontraron artículos.");
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
                    message: "Ocurrió un error inesperado al listar artículos.",
                    data: new { Error = ex.Message }
                );
            }
        }

        public ServiceResult ListarArticulosConDetalle()
        {
            var result = new ServiceResult();

            try
            {
                var list = _articuloRepository.ListarConDetalle();

                if (list == null || !list.Any())
                {
                    return result.NotFound("No se encontraron artículos.");
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
                    message: "Ocurrió un error inesperado al listar artículos.",
                    data: new { Error = ex.Message }
                );
            }
        }

        #endregion Articulos

        #region Cargos

        public ServiceResult ListarCargos()
        {
            var result = new ServiceResult();

            try
            {
                var list = _cargoRepository.List();

                if (list == null || !list.Any())
                {
                    return result.NotFound("No se encontraron cargos.");
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
                    message: "Ocurrió un error inesperado al listar cargos.",
                    data: new { Error = ex.Message }
                );
            }
        }

        #endregion Cargos

        #region Departamentos

        public ServiceResult ListarDepartamentos()
        {
            var result = new ServiceResult();

            try
            {
                var list = _departamentoRepository.List();

                if (list == null || !list.Any())
                {
                    return result.NotFound("No se encontraron departamentos.");
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
                    message: "Ocurrió un error inesperado al listar departamentos.",
                    data: new { Error = ex.Message }
                );
            }
        }

        #endregion Departamentos

        #region Empleados

        public ServiceResult ListarEmpleados()
        {
            var result = new ServiceResult();

            try
            {
                var list = _empleadoRepository.List();

                if (list == null || !list.Any())
                {
                    return result.NotFound("No se encontraron empleados.");
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
                    message: "Ocurrió un error inesperado al listar empleados.",
                    data: new { Error = ex.Message }
                );
            }
        }

        #endregion Empleados

        #region Estados Civiles

        public ServiceResult ListarEstadosCiviles()
        {
            var result = new ServiceResult();

            try
            {
                var list = _estadoCivilRepository.List();

                if (list == null || !list.Any())
                {
                    return result.NotFound("No se encontraron estados civiles.");
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
                    message: "Ocurrió un error inesperado al listar estados civiles.",
                    data: new { Error = ex.Message }
                );
            }
        }

        #endregion Estados Civiles

        #region Municipios

        public ServiceResult ListarMunicipiosPorDepartamento(string deptCodigo)
        {
            var result = new ServiceResult();

            try
            {
                if (string.IsNullOrWhiteSpace(deptCodigo))
                {
                    return result.BadRequest("El código de departamento es requerido.");
                }

                var list = _municipioRepository.ListPorDepartamento(deptCodigo);

                if (list == null || !list.Any())
                {
                    return result.NotFound("No se encontraron municipios para el departamento especificado.");
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
                    message: "Ocurrió un error inesperado al listar municipios.",
                    data: new { Error = ex.Message }
                );
            }
        }

        #endregion Municipios

        #region Sucursales

        public ServiceResult ListarSucursales()
        {
            var result = new ServiceResult();

            try
            {
                var list = _sucursalRepository.List();

                if (list == null || !list.Any())
                {
                    return result.NotFound("No se encontraron sucursales.");
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
                    message: "Ocurrió un error inesperado al listar sucursales.",
                    data: new { Error = ex.Message }
                );
            }
        }

        #endregion Sucursales

        #region Vehiculos

        public ServiceResult ListarVehiculos()
        {
            var result = new ServiceResult();

            try
            {
                var list = _vehiculoRepository.List();

                if (list == null || !list.Any())
                {
                    return result.NotFound("No se encontraron vehículos.");
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
                    message: "Ocurrió un error inesperado al listar vehículos.",
                    data: new { Error = ex.Message }
                );
            }
        }

        #endregion Vehiculos
    }
}