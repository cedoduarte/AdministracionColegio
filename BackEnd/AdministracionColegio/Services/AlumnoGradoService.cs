using AdministracionColegio.CQRS.AlumnoGrados.Command.CreateAlumnoGrado;
using AdministracionColegio.CQRS.AlumnoGrados.Command.DeleteAlumnoGrado;
using AdministracionColegio.CQRS.AlumnoGrados.Command.UpdateAlumnoGrado;
using AdministracionColegio.CQRS.AlumnoGrados.Query.GetAlumnoGradoById;
using AdministracionColegio.CQRS.AlumnoGrados.Query.GetAlumnoGradoList;
using AdministracionColegio.CQRS.AlumnoGrados.ViewModel;
using AdministracionColegio.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.Services
{
    public class AlumnoGradoService : IAlumnoGradoService
    {
        private readonly IMediator _mediator;

        public AlumnoGradoService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult<AlumnoGradoViewModel>> CreateAlumnoGrado(CreateAlumnoGradoCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<AlumnoGradoViewModel>> UpdateAlumnoGrado(UpdateAlumnoGradoCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<AlumnoGradoViewModel>> DeleteAlumnoGrado(int id)
        {
            try
            {
                return await _mediator.Send(new DeleteAlumnoGradoCommand()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<AlumnoGradoViewModel>> GetAlumnoGradoById(int id)
        {
            try
            {
                return await _mediator.Send(new GetAlumnoGradoByIdQuery()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<IEnumerable<AlumnoGradoViewModel>>> GetAlumnoGradoList(GetAlumnoGradoListQuery request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
