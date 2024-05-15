namespace AdministracionColegio.CQRS.Grados.ViewModel
{
    public class GradoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ProfesorId { get; set; }
        public string ProfesorNombre { get; set; }
    }
}
