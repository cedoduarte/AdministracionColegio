using AdministracionColegio.CQRS.Grados.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Grados.Command.DeleteGrado
{
    public class DeleteGradoCommand : IRequest<ActionResult<GradoViewModel>>
    {
        public int Id { get; set; }
    }
}
