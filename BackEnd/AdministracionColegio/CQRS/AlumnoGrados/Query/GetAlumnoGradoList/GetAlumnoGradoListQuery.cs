using AdministracionColegio.CQRS.AlumnoGrados.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.AlumnoGrados.Query.GetAlumnoGradoList
{
    public class GetAlumnoGradoListQuery : IRequest<ActionResult<IEnumerable<AlumnoGradoViewModel>>>
    {
        public string Keyword { get; set; }
        public bool GetAll { get; set; }
    }
}
