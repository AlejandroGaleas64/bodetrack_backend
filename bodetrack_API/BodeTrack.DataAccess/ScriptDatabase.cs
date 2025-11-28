namespace BodeTrack.DataAccess
{
    public static class ScriptDatabase
    {
        #region Articulos

        public const string Articulos_Listar = "[Gral].[SP_Articulos_Listar]";
        public const string Articulos_ListarDetalle = "[Gral].[SP_Articulos_ListarDetalle]";


        #endregion Articulos

        #region Cargos

        public const string Cargos_Listar = "[Gral].[SP_Cargos_Listar]";

        #endregion Cargos

        #region Departamentos

        public const string Departamentos_Listar = "[Gral].[SP_Departamentos_Listar]";

        #endregion Departamentos

        #region Empleados

        public const string Empleados_Listar = "[Gral].[SP_Empleados_Listar]";

        #endregion Empleados

        #region Entradas

        public const string Entrada_Insertar = "[Inve].[SP_Entrada_Insertar]";

        #endregion Entradas

        #region EstadosCiviles

        public const string EstadosCiviles_Listar = "[Gral].[SP_EstadosCiviles_Listar]";

        #endregion EstadosCiviles

        #region Lotes

        public const string Lotes_Listar = "[Inve].[SP_Lotes_Listar]";

        #endregion Lotes

        #region Municipios

        public const string Municipios_ListarPorDepartamento = "[Gral].[SP_Municipios_ListarPorDepartamento]";

        #endregion Municipios

        #region Salidas

        public const string Salida_Insertar = "[Inve].[SP_Salida_Insertar]";
        public const string Salida_Seleccionar = "[Inve].[SP_Salida_ObtenerCompleta]";
        public const string Salida_Recibir = "[Inve].[SP_Salida_Recibir]";
        public const string Salidas_Listar = "[Inve].[SP_Salidas_Listar]";

        #endregion Salidas

        #region Sucursales

        public const string Sucursales_Listar = "[Gral].[SP_Sucursales_Listar]";

        #endregion Sucursales

        #region Usuarios

        public const string Usuario_IniciarSesion = "[Acce].[SP_Usuario_IniciarSesion]";

        #endregion Usuarios

        #region Vehiculos

        public const string Vehiculos_Listar = "[Gral].[SP_Vehiculos_Listar]";

        #endregion Vehiculos
    }
}