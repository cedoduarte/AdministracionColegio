using AdministracionColegio.CQRS.Grados.Command.CreateGrado;
using AdministracionColegio.CQRS.Grados.Command.UpdateGrado;
using AdministracionColegio.CQRS.Grados.Query.GetGradoList;
using AdministracionColegio.CQRS.Grados.ViewModel;
using AdministracionColegio.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradoController : Controller
    {
        private readonly IGradoService _gradoService;

        public GradoController(IGradoService gradoService)
        {
            _gradoService = gradoService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<GradoViewModel>> CreateGrado([FromBody] CreateGradoCommand request)
        {
            try
            {
                return await _gradoService.CreateGrado(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<GradoViewModel>> UpdateGrado([FromBody] UpdateGradoCommand request)
        {
            try
            {
                return await _gradoService.UpdateGrado(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<GradoViewModel>> DeleteGrado([FromRoute] int id)
        {
            try
            {
                return await _gradoService.DeleteGrado(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<GradoViewModel>> GetGradoById([FromRoute] int id)
        {
            try
            {
                return await _gradoService.GetGradoById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("get-list")]
        public async Task<ActionResult<IEnumerable<GradoViewModel>>> GetGradoList([FromQuery] GetGradoListQuery request)
        {
            try
            {
                return await _gradoService.GetGradoList(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
