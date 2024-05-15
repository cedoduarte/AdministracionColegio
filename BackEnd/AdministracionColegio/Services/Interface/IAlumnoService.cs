using AdministracionColegio.CQRS.Alumnos.Command.CreateAlumno;
using AdministracionColegio.CQRS.Alumnos.Command.UpdateAlumno;
using AdministracionColegio.CQRS.Alumnos.Query.GetAlumnoList;
using AdministracionColegio.CQRS.Alumnos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.Services.Interface
{
    public interface IAlumnoService
    {
        Task<ActionResult<AlumnoViewModel>> CreateAlumno(CreateAlumnoCommand request);
        Task<ActionResult<AlumnoViewModel>> UpdateAlumno(UpdateAlumnoCommand request);
        Task<ActionResult<AlumnoViewModel>> DeleteAlumno(int id);
        Task<ActionResult<AlumnoViewModel>> GetAlumnoById(int id);
        Task<ActionResult<IEnumerable<AlumnoViewModel>>> GetAlumnoList(GetAlumnoListQuery request);
    }
}
