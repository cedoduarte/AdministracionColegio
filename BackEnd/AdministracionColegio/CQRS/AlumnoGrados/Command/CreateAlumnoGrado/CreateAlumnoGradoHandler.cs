using AdministracionColegio.CQRS.AlumnoGrados.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.CQRS.AlumnoGrados.Command.CreateAlumnoGrado
{
    public class CreateAlumnoGradoHandler : IRequestHandler<CreateAlumnoGradoCommand, ActionResult<AlumnoGradoViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateAlumnoGradoHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<AlumnoGradoViewModel>> Handle(CreateAlumnoGradoCommand request, CancellationToken cancel)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Seccion))
                {
                    throw new Exception("¡La sección no puede estar vacía!");
                }
                AlumnoGrado newAlumnoGrado = new AlumnoGrado()
                {
                    GradoId = request.GradoId,
                    AlumnoId = request.AlumnoId,
                    Seccion = request.Seccion.Trim()
                };
                await _dbContext.AlumnoGrados.AddAsync(newAlumnoGrado, cancel);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<AlumnoGradoViewModel>(newAlumnoGrado);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
