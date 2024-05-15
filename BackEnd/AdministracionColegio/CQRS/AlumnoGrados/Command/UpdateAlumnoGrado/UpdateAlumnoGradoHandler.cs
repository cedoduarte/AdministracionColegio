using AdministracionColegio.CQRS.AlumnoGrados.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.CQRS.AlumnoGrados.Command.UpdateAlumnoGrado
{
    public class UpdateAlumnoGradoHandler : IRequestHandler<UpdateAlumnoGradoCommand, ActionResult<AlumnoGradoViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateAlumnoGradoHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<AlumnoGradoViewModel>> Handle(UpdateAlumnoGradoCommand request, CancellationToken cancel)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Seccion))
                {
                    throw new Exception("¡La sección no puede estar vacía!");
                }
                AlumnoGrado selectedAlumnoGrado = await _dbContext.AlumnoGrados
                    .Where(a => a.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (selectedAlumnoGrado is null)
                {
                    throw new Exception($"¡La relación de Alumno y Grado con ID {request.Id} no existe!");
                }
                selectedAlumnoGrado.AlumnoId = request.AlumnoId;
                selectedAlumnoGrado.GradoId = request.GradoId;
                selectedAlumnoGrado.Seccion = request.Seccion;
                _dbContext.AlumnoGrados.Update(selectedAlumnoGrado);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<AlumnoGradoViewModel>(selectedAlumnoGrado);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
