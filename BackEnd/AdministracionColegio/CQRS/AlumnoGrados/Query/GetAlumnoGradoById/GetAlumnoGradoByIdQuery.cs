using AdministracionColegio.CQRS.AlumnoGrados.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.AlumnoGrados.Query.GetAlumnoGradoById
{
    public class GetAlumnoGradoByIdQuery : IRequest<ActionResult<AlumnoGradoViewModel>>
    {
        public int Id { get; set; }
    }
}
