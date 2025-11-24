namespace BodeTrack.API.Models.General
{
    public class MunicipiosViewModel
    {
        public string Muni_Codigo { get; set; }

        public string Muni_Descripcion { get; set; }

        public string Dept_Codigo { get; set; }

        public bool Muni_Estado { get; set; }

        public int Muni_Creacion { get; set; }

        public DateTime Muni_FechaCreacion { get; set; }

        public int? Muni_Modificacion { get; set; }

        public DateTime? Muni_FechaModificacion { get; set; }
    }
}