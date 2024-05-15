using AdministracionColegio.CQRS.Profesores.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Profesores.Query.GetProfesorList
{
    public class GetProfesorListQuery : IRequest<ActionResult<IEnumerable<ProfesorViewModel>>>
    {
        public string Keyword { get; set; }
        public bool GetAll { get; set; }
    }
}
