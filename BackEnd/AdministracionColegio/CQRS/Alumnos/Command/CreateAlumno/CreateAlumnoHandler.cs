using AdministracionColegio.CQRS.Alumnos.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.Alumnos.Command.CreateAlumno
{
    public class CreateAlumnoHandler : IRequestHandler<CreateAlumnoCommand, ActionResult<AlumnoViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateAlumnoHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<AlumnoViewModel>> Handle(CreateAlumnoCommand request, CancellationToken cancel)
        {
            try
            {
                ValidateInput(request);
                Alumno newAlumno = new Alumno()
                {
                    Nombre = request.Nombre.Trim(),
                    Apellidos = request.Apellidos.Trim(),
                    Genero = request.Genero.Trim(),
                    FechaNacimiento = request.FechaNacimiento
                };
                await _dbContext.Alumnos.AddAsync(newAlumno, cancel);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<AlumnoViewModel>(newAlumno);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateInput(CreateAlumnoCommand request)
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
