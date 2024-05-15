using AdministracionColegio.CQRS.AlumnoGrados.Command.CreateAlumnoGrado;
using AdministracionColegio.CQRS.AlumnoGrados.Command.UpdateAlumnoGrado;
using AdministracionColegio.CQRS.AlumnoGrados.Query.GetAlumnoGradoList;
using AdministracionColegio.CQRS.AlumnoGrados.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.Services.Interface
{
    public interface IAlumnoGradoService
    {
        Task<ActionResult<AlumnoGradoViewModel>> CreateAlumnoGrado(CreateAlumnoGradoCommand request);
        Task<ActionResult<AlumnoGradoViewModel>> UpdateAlumnoGrado(UpdateAlumnoGradoCommand request);
        Task<ActionResult<AlumnoGradoViewModel>> DeleteAlumnoGrado(int id);
        Task<ActionResult<AlumnoGradoViewModel>> GetAlumnoGradoById(int id);
        Task<ActionResult<IEnumerable<AlumnoGradoViewModel>>> GetAlumnoGradoList(GetAlumnoGradoListQuery request);
    }
}
