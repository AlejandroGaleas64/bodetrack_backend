namespace BodeTrack.API.Models.General
{
    public class CargosViewModel
    {
        public int Carg_Id { get; set; }

        public string Carg_Descripcion { get; set; }

        public bool Carg_Estado { get; set; }

        public int Carg_Creacion { get; set; }

        public DateTime Carg_FechaCreacion { get; set; }

        public int? Carg_Modificacion { get; set; }

        public DateTime? Carg_FechaModificacion { get; set; }
    }
}