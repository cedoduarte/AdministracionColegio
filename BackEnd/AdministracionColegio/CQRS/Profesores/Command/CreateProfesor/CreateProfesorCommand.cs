using AdministracionColegio.CQRS.Profesores.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Profesores.Command.CreateProfesor
{
    public class CreateProfesorCommand : IRequest<ActionResult<ProfesorViewModel>>
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
    }
}
