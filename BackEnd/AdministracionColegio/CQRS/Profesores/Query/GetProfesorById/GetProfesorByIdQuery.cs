using AdministracionColegio.CQRS.Profesores.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Profesores.Query.GetProfesorById
{
    public class GetProfesorByIdQuery : IRequest<ActionResult<ProfesorViewModel>>
    {
        public int Id { get; set; }
    }
}
