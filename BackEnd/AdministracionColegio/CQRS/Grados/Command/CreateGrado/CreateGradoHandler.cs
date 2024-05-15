using AdministracionColegio.CQRS.Grados.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.CQRS.Grados.Command.CreateGrado
{
    public class CreateGradoHandler : IRequestHandler<CreateGradoCommand, ActionResult<GradoViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGradoHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<GradoViewModel>> Handle(CreateGradoCommand request, CancellationToken cancel)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Nombre))
                {
                    throw new Exception("¡El nombre no puede estar vacío!");
                }
                var existingGrado = _dbContext.Grados
                    .Where(g => g.ProfesorId == request.ProfesorId)
                    .FirstOrDefaultAsync(cancel);
                if (existingGrado is not null)
                {
                    throw new Exception("¡El Profesor seleccionado ya está asignado a un Grado!");
                }
                Grado newGrado = new Grado()
                {
                    Nombre = request.Nombre.Trim(),
                    ProfesorId = request.ProfesorId
                };
                await _dbContext.Grados.AddAsync(newGrado, cancel);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<GradoViewModel>(newGrado);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
