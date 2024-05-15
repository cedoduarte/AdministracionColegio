using AdministracionColegio.CQRS.Alumnos.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.CQRS.Alumnos.Command.UpdateAlumno
{
    public class UpdateAlumnoHandler : IRequestHandler<UpdateAlumnoCommand, ActionResult<AlumnoViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateAlumnoHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<AlumnoViewModel>> Handle(UpdateAlumnoCommand request, CancellationToken cancel)
        {
            try
            {
                ValidateInput(request);
                Alumno selectedAlumno = await _dbContext.Alumnos
                    .Where(a => a.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (selectedAlumno is null)
                {
                    throw new Exception($"¡El alumno con ID {request.Id} no existe!");
                }
                selectedAlumno.Nombre = request.Nombre.Trim();
                selectedAlumno.Apellidos = request.Apellidos.Trim();
                selectedAlumno.Genero = request.Genero.Trim();
                selectedAlumno.FechaNacimiento = request.FechaNacimiento;
                _dbContext.Alumnos.Update(selectedAlumno);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<AlumnoViewModel>(selectedAlumno);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateInput(UpdateAlumnoCommand request)
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