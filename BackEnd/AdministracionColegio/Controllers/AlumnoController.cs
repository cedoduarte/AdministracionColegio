using AdministracionColegio.CQRS.Alumnos.Command.CreateAlumno;
using AdministracionColegio.CQRS.Alumnos.Command.UpdateAlumno;
using AdministracionColegio.CQRS.Alumnos.Query.GetAlumnoList;
using AdministracionColegio.CQRS.Alumnos.ViewModel;
using AdministracionColegio.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnoController : Controller
    {
        private readonly IAlumnoService _alumnoService;

        public AlumnoController(IAlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<AlumnoViewModel>> CreateAlumno([FromBody] CreateAlumnoCommand request)
        {
            try
            {
                return await _alumnoService.CreateAlumno(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<AlumnoViewModel>> UpdateAlumno([FromBody] UpdateAlumnoCommand request)
        {
            try
            {
                return await _alumnoService.UpdateAlumno(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<AlumnoViewModel>> DeleteAlumno([FromRoute] int id)
        {
            try
            {
                return await _alumnoService.DeleteAlumno(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<AlumnoViewModel>> GetAlumnoById([FromRoute] int id)
        {
            try
            {
                return await _alumnoService.GetAlumnoById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("get-list")]
        public async Task<ActionResult<IEnumerable<AlumnoViewModel>>> GetAlumnoList([FromQuery] GetAlumnoListQuery request)
        {
            try
            {
                return await _alumnoService.GetAlumnoList(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
