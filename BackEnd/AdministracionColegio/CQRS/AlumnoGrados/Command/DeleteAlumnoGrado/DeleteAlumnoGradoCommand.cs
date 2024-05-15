using AdministracionColegio.CQRS.AlumnoGrados.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.AlumnoGrados.Command.DeleteAlumnoGrado
{
    public class DeleteAlumnoGradoCommand : IRequest<ActionResult<AlumnoGradoViewModel>>
    {
        public int Id { get; set; }
    }
}
