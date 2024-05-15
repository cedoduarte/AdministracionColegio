using AdministracionColegio.CQRS.Grados.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.CQRS.Grados.Command.UpdateGrado
{
    public class UpdateGradoHandler : IRequestHandler<UpdateGradoCommand, ActionResult<GradoViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateGradoHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<GradoViewModel>> Handle(UpdateGradoCommand request, CancellationToken cancel)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Nombre))
                {
                    throw new Exception("¡El nombre no puede estar vacío!");
                }
                Grado selectedGrado = await _dbContext.Grados
                    .Where(g => g.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (selectedGrado is null)
                {
                    throw new Exception($"¡El grado con ID {request.Id} no existe!");
                }
                selectedGrado.Nombre = request.Nombre.Trim();
                selectedGrado.ProfesorId = request.ProfesorId;
                _dbContext.Grados.Update(selectedGrado);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<GradoViewModel>(selectedGrado);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
