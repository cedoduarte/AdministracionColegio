using AdministracionColegio.CQRS.Alumnos.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.CQRS.Alumnos.Command.DeleteAlumno
{
    public class DeleteAlumnoHandler : IRequestHandler<DeleteAlumnoCommand, ActionResult<AlumnoViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteAlumnoHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<AlumnoViewModel>> Handle(DeleteAlumnoCommand request, CancellationToken cancel)
        {
            try
            {
                Alumno existingAlumno = await _dbContext.Alumnos
                    .Where(a => a.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (existingAlumno is not null)
                {
                    _dbContext.Alumnos.Remove(existingAlumno);
                    await _dbContext.SaveChangesAsync(cancel);
                    return _mapper.Map<AlumnoViewModel>(existingAlumno);
                }
                throw new Exception($"¡No existe alumno con ID {request.Id}!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
