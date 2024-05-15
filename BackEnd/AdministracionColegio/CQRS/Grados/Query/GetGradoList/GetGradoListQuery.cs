using AdministracionColegio.CQRS.Grados.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Grados.Query.GetGradoList
{
    public class GetGradoListQuery : IRequest<ActionResult<IEnumerable<GradoViewModel>>>
    {
        public string Keyword { get; set; }
        public bool GetAll { get; set; }
    }
}
