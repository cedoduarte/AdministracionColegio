using AdministracionColegio.CQRS.Profesores.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Profesores.Command.UpdateProfesor
{
    public class UpdateProfesorCommand : IRequest<ActionResult<ProfesorViewModel>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
    }
}
