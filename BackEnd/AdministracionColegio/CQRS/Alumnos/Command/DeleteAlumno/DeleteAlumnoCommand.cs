using AdministracionColegio.CQRS.Alumnos.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Alumnos.Command.DeleteAlumno
{
    public class DeleteAlumnoCommand : IRequest<ActionResult<AlumnoViewModel>>
    {
        public int Id { get; set; }
    }
}
