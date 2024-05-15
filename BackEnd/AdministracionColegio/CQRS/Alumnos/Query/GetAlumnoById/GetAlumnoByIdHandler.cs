using AdministracionColegio.CQRS.Alumnos.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.CQRS.Alumnos.Query.GetAlumnoById
{
    public class GetAlumnoByIdHandler : IRequestHandler<GetAlumnoByIdQuery, ActionResult<AlumnoViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAlumnoByIdHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<AlumnoViewModel>> Handle(GetAlumnoByIdQuery request, CancellationToken cancel)
        {
            try
            {
                Alumno selectedAlumno = await _dbContext.Alumnos
                    .Where(a => a.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (selectedAlumno is null)
                {
                    throw new Exception($"¡El alumno con ID {request.Id} no existe!");                
                }
                return _mapper.Map<AlumnoViewModel>(selectedAlumno);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
