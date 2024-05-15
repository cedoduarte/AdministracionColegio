using AdministracionColegio.CQRS.AlumnoGrados.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AdministracionColegio.CQRS.AlumnoGrados.Query.GetAlumnoGradoList
{
    public class GetAlumnoGradoListHandler : IRequestHandler<GetAlumnoGradoListQuery, ActionResult<IEnumerable<AlumnoGradoViewModel>>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAlumnoGradoListHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<AlumnoGradoViewModel>>> Handle(GetAlumnoGradoListQuery request, CancellationToken cancel)
        {
            try
            {
                if (request.GetAll)
                {
                    return new OkObjectResult(
                        _mapper.Map<IEnumerable<AlumnoGradoViewModel>>(
                            await _dbContext.AlumnoGrados
                                .Include(a => a.Alumno)
                                .Include(a => a.Grado)
                                .ToListAsync(cancel)));
                }
                if (string.IsNullOrEmpty(request.Keyword))
                {
                    throw new Exception("¡La palabra clave no puede estar vacía!");
                }
                string keyword = request.Keyword.ToLower().Trim();
                return new OkObjectResult(
                    _mapper.Map<IEnumerable<AlumnoGradoViewModel>>(
                        await _dbContext.AlumnoGrados
                        .Where(a => a.Seccion.Contains(keyword))
                        .Include(a => a.Alumno)
                        .Include(a => a.Grado)
                        .ToListAsync(cancel)));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
