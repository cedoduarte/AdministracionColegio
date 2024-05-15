using AdministracionColegio.CQRS.AlumnoGrados.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.AlumnoGrados.Command.CreateAlumnoGrado
{
    public class CreateAlumnoGradoCommand : IRequest<ActionResult<AlumnoGradoViewModel>>
    {
        public int AlumnoId { get; set; }
        public int GradoId { get; set; }
        public string Seccion { get; set; } // grupo
    }
}
