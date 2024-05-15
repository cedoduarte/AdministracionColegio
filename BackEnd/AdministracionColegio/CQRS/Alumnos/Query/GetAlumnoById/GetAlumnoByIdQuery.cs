using AdministracionColegio.CQRS.Alumnos.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Alumnos.Query.GetAlumnoById
{
    public class GetAlumnoByIdQuery : IRequest<ActionResult<AlumnoViewModel>>
    {
        public int Id { get; set; }
    }
}
