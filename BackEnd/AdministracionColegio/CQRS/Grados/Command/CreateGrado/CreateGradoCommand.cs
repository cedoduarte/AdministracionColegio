using AdministracionColegio.CQRS.Grados.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Grados.Command.CreateGrado
{
    public class CreateGradoCommand : IRequest<ActionResult<GradoViewModel>>
    {
        public string Nombre { get; set; }
        public int ProfesorId { get; set; }
    }
}
