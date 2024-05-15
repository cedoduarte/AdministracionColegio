using AdministracionColegio.CQRS.AlumnoGrados.Command.CreateAlumnoGrado;
using AdministracionColegio.CQRS.AlumnoGrados.Command.UpdateAlumnoGrado;
using AdministracionColegio.CQRS.AlumnoGrados.Query.GetAlumnoGradoList;
using AdministracionColegio.CQRS.AlumnoGrados.ViewModel;
using AdministracionColegio.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnoGradoController : Controller
    {
        private readonly IAlumnoGradoService _alumnoGradoService;

        public AlumnoGradoController(IAlumnoGradoService alumnoGradoService)
        {
            _alumnoGradoService = alumnoGradoService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<AlumnoGradoViewModel>> CreateAlumnoGrado([FromBody] CreateAlumnoGradoCommand request)
        {
            try
            {
                return await _alumnoGradoService.CreateAlumnoGrado(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<AlumnoGradoViewModel>> UpdateAlumnoGrado([FromBody] UpdateAlumnoGradoCommand request)
        {
            try
            {
                return await _alumnoGradoService.UpdateAlumnoGrado(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<AlumnoGradoViewModel>> DeleteAlumnoGrado([FromRoute] int id)
        {
            try
            {
                return await _alumnoGradoService.DeleteAlumnoGrado(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<AlumnoGradoViewModel>> GetAlumnoGradoById([FromRoute] int id)
        {
            try
            {
                return await _alumnoGradoService.GetAlumnoGradoById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("get-list")]
        public async Task<ActionResult<IEnumerable<AlumnoGradoViewModel>>> GetAlumnoGradoList([FromQuery] GetAlumnoGradoListQuery request)
        {
            try
            {
                return await _alumnoGradoService.GetAlumnoGradoList(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
