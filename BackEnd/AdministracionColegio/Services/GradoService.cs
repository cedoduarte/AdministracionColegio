using AdministracionColegio.CQRS.Grados.Command.CreateGrado;
using AdministracionColegio.CQRS.Grados.Command.DeleteGrado;
using AdministracionColegio.CQRS.Grados.Command.UpdateGrado;
using AdministracionColegio.CQRS.Grados.Query.GetGradoById;
using AdministracionColegio.CQRS.Grados.Query.GetGradoList;
using AdministracionColegio.CQRS.Grados.ViewModel;
using AdministracionColegio.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.Services
{
    public class GradoService : IGradoService
    {
        private readonly IMediator _mediator;

        public GradoService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult<GradoViewModel>> CreateGrado(CreateGradoCommand request)
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

        public async Task<ActionResult<GradoViewModel>> UpdateGrado(UpdateGradoCommand request)
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

        public async Task<ActionResult<GradoViewModel>> DeleteGrado(int id)
        {
            try
            {
                return await _mediator.Send(new DeleteGradoCommand()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<GradoViewModel>> GetGradoById(int id)
        {
            try
            {
                return await _mediator.Send(new GetGradoByIdQuery()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<IEnumerable<GradoViewModel>>> GetGradoList(GetGradoListQuery request)
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
