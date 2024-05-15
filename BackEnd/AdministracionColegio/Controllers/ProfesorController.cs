using AdministracionColegio.CQRS.Profesores.Command.CreateProfesor;
using AdministracionColegio.CQRS.Profesores.Command.UpdateProfesor;
using AdministracionColegio.CQRS.Profesores.Query.GetProfesorList;
using AdministracionColegio.CQRS.Profesores.ViewModel;
using AdministracionColegio.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesorController : Controller
    {
        private readonly IProfesorService _profesorService;

        public ProfesorController(IProfesorService profesorService)
        {
            _profesorService = profesorService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ProfesorViewModel>> CreateProfesor([FromBody] CreateProfesorCommand request)
        {
            try
            {
                return await _profesorService.CreateProfesor(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<ProfesorViewModel>> UpdateProfesor([FromBody] UpdateProfesorCommand request)
        {
            try
            {
                return await _profesorService.UpdateProfesor(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ProfesorViewModel>> DeleteProfesor([FromRoute] int id)
        {
            try
            {
                return await _profesorService.DeleteProfesor(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<ProfesorViewModel>> GetProfesorById([FromRoute] int id)
        {
            try
            {
                return await _profesorService.GetProfesorById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("get-list")]
        public async Task<ActionResult<IEnumerable<ProfesorViewModel>>> GetProfesorList([FromQuery] GetProfesorListQuery request)
        {
            try
            {
                return await _profesorService.GetProfesorList(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
