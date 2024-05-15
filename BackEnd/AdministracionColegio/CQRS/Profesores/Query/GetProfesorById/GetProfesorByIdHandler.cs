using AdministracionColegio.CQRS.Profesores.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.CQRS.Profesores.Query.GetProfesorById
{
    public class GetProfesorByIdHandler : IRequestHandler<GetProfesorByIdQuery, ActionResult<ProfesorViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProfesorByIdHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<ProfesorViewModel>> Handle(GetProfesorByIdQuery request, CancellationToken cancel)
        {
            try
            {
                Profesor selectedProfesor = await _dbContext.Profesores
                    .Where(p => p.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (selectedProfesor is null)
                {
                    throw new Exception($"¡El profesor con ID {request.Id} no existe!");
                }
                return _mapper.Map<ProfesorViewModel>(selectedProfesor);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
