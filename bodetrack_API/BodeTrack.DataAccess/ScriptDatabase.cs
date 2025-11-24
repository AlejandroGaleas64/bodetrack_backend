namespace BodeTrack.DataAccess
{
    public static class ScriptDatabase
    {
        #region Departamentos

        public const string Departamentos_Listar = "[Gral].[SP_Departamentos_Listar]";

        #endregion Departamentos

        #region Entradas

        public const string Entrada_Insertar = "[Inve].[SP_Entrada_Insertar]";

        #endregion Entradas

        #region Salidas

        public const string Salida_Insertar = "[Inve].[SP_Salida_Insertar]";
        public const string Salida_Seleccionar = "[Inve].[SP_Salida_Seleccionar]";
        public const string Salida_Recibir = "[Inve].[SP_Salida_Recibir]";
        public const string Salidas_Listar = "[Inve].[SP_Salidas_Listar]";

        #endregion Salidas

        #region Usuarios

        public const string Usuario_IniciarSesion = "[Acce].[SP_Usuario_IniciarSesion]";

        #endregion Usuarios
    }
}