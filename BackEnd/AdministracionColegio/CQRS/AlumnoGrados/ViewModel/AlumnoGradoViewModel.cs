namespace AdministracionColegio.CQRS.AlumnoGrados.ViewModel
{
    public class AlumnoGradoViewModel
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public int GradoId { get; set; }
        public string AlumnoNombre { get; set; }
        public string GradoNombre { get; set; }
        public string Seccion { get; set; } // grupo
    }
}
