using AdministracionColegio.CQRS.Profesores.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.CQRS.Profesores.Command.DeleteProfesor
{
    public class DeleteProfesorHandler : IRequestHandler<DeleteProfesorCommand, ActionResult<ProfesorViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteProfesorHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<ProfesorViewModel>> Handle(DeleteProfesorCommand request, CancellationToken cancel)
        {
            try
            {
                Profesor existingProfesor = await _dbContext.Profesores
                    .Where(p => p.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (existingProfesor is not null)
                {
                    _dbContext.Profesores.Remove(existingProfesor);
                    await _dbContext.SaveChangesAsync(cancel);
                    return _mapper.Map<ProfesorViewModel>(existingProfesor);
                }
                throw new Exception($"¡No existe profesor con ID {request.Id}!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
