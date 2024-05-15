using AdministracionColegio.CQRS.Alumnos.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Alumnos.Query.GetAlumnoList
{
    public class GetAlumnoListQuery : IRequest<ActionResult<IEnumerable<AlumnoViewModel>>>
    {
        public string Keyword { get; set; }
        public bool GetAll { get; set; }
    }
}
