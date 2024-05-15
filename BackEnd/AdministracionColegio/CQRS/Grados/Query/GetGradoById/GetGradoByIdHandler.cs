using AdministracionColegio.CQRS.Grados.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.CQRS.Grados.Query.GetGradoById
{
    public class GetGradoByIdHandler : IRequestHandler<GetGradoByIdQuery, ActionResult<GradoViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGradoByIdHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<GradoViewModel>> Handle(GetGradoByIdQuery request, CancellationToken cancel)
        {
            try
            {
                Grado selectedGrado = await _dbContext.Grados
                    .Where(g => g.Id == request.Id)
                    .Include(g => g.Profesor)
                    .FirstOrDefaultAsync(cancel);
                if (selectedGrado is null)
                {
                    throw new Exception($"¡El grado con ID {request.Id} no existe!");
                }
                return _mapper.Map<GradoViewModel>(selectedGrado);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
