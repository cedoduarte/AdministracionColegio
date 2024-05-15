using AdministracionColegio.CQRS.Alumnos.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionColegio.CQRS.Alumnos.Query.GetAlumnoList
{
    public class GetAlumnoListHandler : IRequestHandler<GetAlumnoListQuery, ActionResult<IEnumerable<AlumnoViewModel>>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAlumnoListHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<AlumnoViewModel>>> Handle(GetAlumnoListQuery request, CancellationToken cancel)
        {
            try
            {
                if (request.GetAll)
                {
                    return new OkObjectResult(
                        _mapper.Map<IEnumerable<AlumnoViewModel>>(
                            await _dbContext.Alumnos.ToListAsync(cancel)));
                }
                if (string.IsNullOrEmpty(request.Keyword))
                {
                    throw new Exception("¡La palabra clave no puede estar vacía!");
                }
                string keyword = request.Keyword.ToLower().Trim();
                return new OkObjectResult(
                    _mapper.Map<IEnumerable<AlumnoViewModel>>(
                        await _dbContext.Alumnos
                        .Where(a => a.Nombre.Contains(keyword)
                            || a.Apellidos.Contains(keyword)
                            || a.Genero.Contains(keyword))
                        .ToListAsync(cancel)));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
