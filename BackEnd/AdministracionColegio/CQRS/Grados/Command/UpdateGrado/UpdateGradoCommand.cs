using AdministracionColegio.CQRS.Grados.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Grados.Command.UpdateGrado
{
    public class UpdateGradoCommand : IRequest<ActionResult<GradoViewModel>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ProfesorId { get; set; }
    }
}
