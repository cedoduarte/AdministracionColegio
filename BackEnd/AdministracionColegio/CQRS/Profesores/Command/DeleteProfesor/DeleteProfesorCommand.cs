using AdministracionColegio.CQRS.Profesores.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Profesores.Command.DeleteProfesor
{
    public class DeleteProfesorCommand : IRequest<ActionResult<ProfesorViewModel>>
    {
        public int Id { get; set; }
    }
}
