using AdministracionColegio.CQRS.AlumnoGrados.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.CQRS.AlumnoGrados.Command.DeleteAlumnoGrado
{
    public class DeleteAlumnoGradoHandler : IRequestHandler<DeleteAlumnoGradoCommand, ActionResult<AlumnoGradoViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteAlumnoGradoHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<AlumnoGradoViewModel>> Handle(DeleteAlumnoGradoCommand request, CancellationToken cancel)
        {
            try
            {
                AlumnoGrado existingAlumnoGrado = await _dbContext.AlumnoGrados
                    .Where(a => a.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (existingAlumnoGrado is not null)
                {
                    _dbContext.AlumnoGrados.Remove(existingAlumnoGrado);
                    await _dbContext.SaveChangesAsync(cancel);
                    return _mapper.Map<AlumnoGradoViewModel>(existingAlumnoGrado);
                }
                throw new Exception($"¡No existe la relación de Alumno y Grado con con ID {request.Id}!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
