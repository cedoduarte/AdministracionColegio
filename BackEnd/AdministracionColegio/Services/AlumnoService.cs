using AdministracionColegio.CQRS.Alumnos.Command.CreateAlumno;
using AdministracionColegio.CQRS.Alumnos.Command.DeleteAlumno;
using AdministracionColegio.CQRS.Alumnos.Command.UpdateAlumno;
using AdministracionColegio.CQRS.Alumnos.Query.GetAlumnoById;
using AdministracionColegio.CQRS.Alumnos.Query.GetAlumnoList;
using AdministracionColegio.CQRS.Alumnos.ViewModel;
using AdministracionColegio.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.Services
{
    public class AlumnoService : IAlumnoService
    {
        private readonly IMediator _mediator;

        public AlumnoService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult<AlumnoViewModel>> CreateAlumno(CreateAlumnoCommand request)
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

        public async Task<ActionResult<AlumnoViewModel>> UpdateAlumno(UpdateAlumnoCommand request)
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

        public async Task<ActionResult<AlumnoViewModel>> DeleteAlumno(int id)
        {
            try
            {
                return await _mediator.Send(new DeleteAlumnoCommand()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<AlumnoViewModel>> GetAlumnoById(int id)
        {
            try
            {
                return await _mediator.Send(new GetAlumnoByIdQuery()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<IEnumerable<AlumnoViewModel>>> GetAlumnoList(GetAlumnoListQuery request)
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
