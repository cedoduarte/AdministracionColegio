using AdministracionColegio.CQRS.Grados.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AdministracionColegio.CQRS.Grados.Query.GetGradoList
{
    public class GetGradoListHandler : IRequestHandler<GetGradoListQuery, ActionResult<IEnumerable<GradoViewModel>>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGradoListHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<GradoViewModel>>> Handle(GetGradoListQuery request, CancellationToken cancel)
        {
            try
            {
                if (request.GetAll)
                {
                    return new OkObjectResult(
                        _mapper.Map<IEnumerable<GradoViewModel>>(
                            await _dbContext.Grados
                                .Include(g => g.Profesor)
                                .ToListAsync(cancel)));
                }
                if (string.IsNullOrEmpty(request.Keyword))
                {
                    throw new Exception("¡La palabra clave no puede estar vacía!");
                }
                string keyword = request.Keyword.ToLower().Trim();
                return new OkObjectResult(
                    _mapper.Map<IEnumerable<GradoViewModel>>(
                        await _dbContext.Grados
                        .Where(g => g.Nombre.Contains(keyword))
                        .Include(g => g.Profesor)
                        .ToListAsync(cancel)));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
