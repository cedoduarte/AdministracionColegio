using AdministracionColegio.CQRS.AlumnoGrados.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.AlumnoGrados.Command.UpdateAlumnoGrado
{
    public class UpdateAlumnoGradoCommand : IRequest<ActionResult<AlumnoGradoViewModel>>
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public int GradoId { get; set; }
        public string Seccion { get; set; } // grupo
    }
}
