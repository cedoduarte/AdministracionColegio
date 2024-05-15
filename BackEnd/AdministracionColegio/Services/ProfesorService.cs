using AdministracionColegio.CQRS.Profesores.Command.CreateProfesor;
using AdministracionColegio.CQRS.Profesores.Command.DeleteProfesor;
using AdministracionColegio.CQRS.Profesores.Command.UpdateProfesor;
using AdministracionColegio.CQRS.Profesores.Query.GetProfesorById;
using AdministracionColegio.CQRS.Profesores.Query.GetProfesorList;
using AdministracionColegio.CQRS.Profesores.ViewModel;
using AdministracionColegio.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly IMediator _mediator;

        public ProfesorService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult<ProfesorViewModel>> CreateProfesor(CreateProfesorCommand request)
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

        public async Task<ActionResult<ProfesorViewModel>> UpdateProfesor(UpdateProfesorCommand request)
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

        public async Task<ActionResult<ProfesorViewModel>> DeleteProfesor(int id)
        {
            try
            {
                return await _mediator.Send(new DeleteProfesorCommand()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<ProfesorViewModel>> GetProfesorById(int id)
        {
            try
            {
                return await _mediator.Send(new GetProfesorByIdQuery()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<IEnumerable<ProfesorViewModel>>> GetProfesorList(GetProfesorListQuery request)
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
