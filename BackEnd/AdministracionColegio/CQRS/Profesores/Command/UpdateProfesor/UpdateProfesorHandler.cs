using AdministracionColegio.CQRS.Profesores.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AdministracionColegio.CQRS.Profesores.Command.UpdateProfesor
{
    public class UpdateProfesorHandler : IRequestHandler<UpdateProfesorCommand, ActionResult<ProfesorViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateProfesorHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<ProfesorViewModel>> Handle(UpdateProfesorCommand request, CancellationToken cancel)
        {
            try
            {
                ValidateInput(request);
                Profesor selectedProfesor = await _dbContext.Profesores
                    .Where(p => p.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (selectedProfesor is null)
                {
                    throw new Exception($"¡El profesor con ID {request.Id} no existe!");
                }
                selectedProfesor.Nombre = request.Nombre.Trim();
                selectedProfesor.Apellidos = request.Apellidos.Trim();
                selectedProfesor.Genero = request.Genero.Trim();
                _dbContext.Profesores.Update(selectedProfesor);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<ProfesorViewModel>(selectedProfesor);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateInput(UpdateProfesorCommand request)
        {
            if (string.IsNullOrEmpty(request.Nombre))
            {
                throw new Exception("¡El nombre no puede estar vacío!");
            }
            if (string.IsNullOrEmpty(request.Apellidos))
            {
                throw new Exception("¡El apellido no puede estar vacío!");
            }
            if (string.IsNullOrEmpty(request.Genero))
            {
                throw new Exception("¡El género no puede estar vacío!");
            }
        }
    }
}
