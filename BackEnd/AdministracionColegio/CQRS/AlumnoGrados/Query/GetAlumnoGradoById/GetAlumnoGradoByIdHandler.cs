using AdministracionColegio.CQRS.AlumnoGrados.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.CQRS.AlumnoGrados.Query.GetAlumnoGradoById
{
    public class GetAlumnoGradoByIdHandler : IRequestHandler<GetAlumnoGradoByIdQuery, ActionResult<AlumnoGradoViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAlumnoGradoByIdHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<AlumnoGradoViewModel>> Handle(GetAlumnoGradoByIdQuery request, CancellationToken cancel)
        {
            try
            {
                AlumnoGrado selectedAlumnoGrado = await _dbContext.AlumnoGrados
                    .Where(a => a.Id == request.Id)
                    .Include(a => a.Alumno)
                    .Include(a => a.Grado)
                    .FirstOrDefaultAsync(cancel);
                if (selectedAlumnoGrado is null)
                {
                    throw new Exception($"¡La relación de Alumno y Grado con ID {request.Id} no existe!");
                }
                return _mapper.Map<AlumnoGradoViewModel>(selectedAlumnoGrado);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
