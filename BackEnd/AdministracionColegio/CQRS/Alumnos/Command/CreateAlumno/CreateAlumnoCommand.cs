using AdministracionColegio.CQRS.Alumnos.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Alumnos.Command.CreateAlumno
{
    public class CreateAlumnoCommand : IRequest<ActionResult<AlumnoViewModel>>
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
