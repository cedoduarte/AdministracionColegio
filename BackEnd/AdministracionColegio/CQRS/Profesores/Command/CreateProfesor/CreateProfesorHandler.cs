using AdministracionColegio.CQRS.Profesores.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Profesores.Command.CreateProfesor
{
    public class CreateProfesorHandler : IRequestHandler<CreateProfesorCommand, ActionResult<ProfesorViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateProfesorHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<ProfesorViewModel>> Handle(CreateProfesorCommand request, CancellationToken cancel)
        {
            try
            {
                ValidateInput(request);
                Profesor newProfesor = new Profesor()
                {
                    Nombre = request.Nombre.Trim(),
                    Apellidos = request.Apellidos.Trim(),
                    Genero = request.Genero.Trim()
                };
                await _dbContext.Profesores.AddAsync(newProfesor, cancel);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<ProfesorViewModel>(newProfesor);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateInput(CreateProfesorCommand request)
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
