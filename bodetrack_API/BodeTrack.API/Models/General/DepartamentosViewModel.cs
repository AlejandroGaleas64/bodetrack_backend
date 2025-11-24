namespace BodeTrack.API.Models.General
{
    public class DepartamentosViewModel
    {
        public string Dept_Codigo { get; set; }

        public string Dept_Descripcion { get; set; }

        public bool Dept_Estado { get; set; }

        public int Dept_Creacion { get; set; }

        public DateTime Dept_FechaCreacion { get; set; }

        public int? Dept_Modificacion { get; set; }

        public DateTime? Dept_FechaModificacion { get; set; }
    }
}