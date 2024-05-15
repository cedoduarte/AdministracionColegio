using AdministracionColegio.CQRS.Profesores.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.CQRS.Profesores.Query.GetProfesorList
{
    public class GetProfesorListHandler : IRequestHandler<GetProfesorListQuery, ActionResult<IEnumerable<ProfesorViewModel>>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProfesorListHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<ProfesorViewModel>>> Handle(GetProfesorListQuery request, CancellationToken cancel)
        {
            try
            {
                if (request.GetAll)
                {
                    return new OkObjectResult(
                        _mapper.Map<IEnumerable<ProfesorViewModel>>(
                            await _dbContext.Profesores.ToListAsync(cancel)));
                }
                if (string.IsNullOrEmpty(request.Keyword))
                {
                    throw new Exception("¡La palabra clave no puede estar vacía!");
                }
                string keyword = request.Keyword.ToLower().Trim();
                return new OkObjectResult(
                    _mapper.Map<IEnumerable<ProfesorViewModel>>(
                        await _dbContext.Profesores
                        .Where(p => p.Nombre.Contains(keyword)
                            || p.Apellidos.Contains(keyword)
                            || p.Genero.Contains(keyword))
                        .ToListAsync(cancel)));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
