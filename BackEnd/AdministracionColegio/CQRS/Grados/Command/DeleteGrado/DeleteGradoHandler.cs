using AdministracionColegio.CQRS.Grados.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.CQRS.Grados.Command.DeleteGrado
{
    public class DeleteGradoHandler : IRequestHandler<DeleteGradoCommand, ActionResult<GradoViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteGradoHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<GradoViewModel>> Handle(DeleteGradoCommand request, CancellationToken cancel)
        {
            try
            {
                Grado existingGrado = await _dbContext.Grados
                    .Where(g => g.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (existingGrado is not null)
                {
                    _dbContext.Grados.Remove(existingGrado);
                    await _dbContext.SaveChangesAsync(cancel);
                    return _mapper.Map<GradoViewModel>(existingGrado);
                }
                throw new Exception($"¡No existe el grado con ID {request.Id}!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
