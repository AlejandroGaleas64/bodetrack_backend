namespace BodeTrack.API.Models.Acceso
{
    public class UsuariosViewModel
    {
        public int Usua_Id { get; set; }

        public string Usua_NombreUsuario { get; set; }

        public string Usua_Clave { get; set; }

        public bool Usua_EsAdmin { get; set; }

        public int Empl_Id { get; set; }

        public bool Usua_Estado { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Usua_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Usua_FechaModificacion { get; set; }
    }
}