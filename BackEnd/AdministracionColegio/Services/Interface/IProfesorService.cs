using AdministracionColegio.CQRS.Profesores.Command.CreateProfesor;
using AdministracionColegio.CQRS.Profesores.Command.UpdateProfesor;
using AdministracionColegio.CQRS.Profesores.Query.GetProfesorList;
using AdministracionColegio.CQRS.Profesores.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.Services.Interface
{
    public interface IProfesorService
    {
        Task<ActionResult<ProfesorViewModel>> CreateProfesor(CreateProfesorCommand request);
        Task<ActionResult<ProfesorViewModel>> UpdateProfesor(UpdateProfesorCommand request);
        Task<ActionResult<ProfesorViewModel>> DeleteProfesor(int id);
        Task<ActionResult<ProfesorViewModel>> GetProfesorById(int id);
        Task<ActionResult<IEnumerable<ProfesorViewModel>>> GetProfesorList(GetProfesorListQuery request);
    }
}
