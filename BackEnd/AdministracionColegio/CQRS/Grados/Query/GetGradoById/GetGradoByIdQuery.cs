using AdministracionColegio.CQRS.Grados.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Grados.Query.GetGradoById
{
    public class GetGradoByIdQuery : IRequest<ActionResult<GradoViewModel>>
    {
        public int Id { get; set; }
    }
}
