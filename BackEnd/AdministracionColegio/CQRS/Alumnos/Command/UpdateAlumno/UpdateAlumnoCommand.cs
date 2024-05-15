using AdministracionColegio.CQRS.Alumnos.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Alumnos.Command.UpdateAlumno
{
    public class UpdateAlumnoCommand : IRequest<ActionResult<AlumnoViewModel>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
