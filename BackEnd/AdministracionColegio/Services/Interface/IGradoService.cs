using AdministracionColegio.CQRS.Grados.Command.CreateGrado;
using AdministracionColegio.CQRS.Grados.Command.UpdateGrado;
using AdministracionColegio.CQRS.Grados.Query.GetGradoList;
using AdministracionColegio.CQRS.Grados.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionColegio.Services.Interface
{
    public interface IGradoService
    {
        Task<ActionResult<GradoViewModel>> CreateGrado(CreateGradoCommand request);
        Task<ActionResult<GradoViewModel>> UpdateGrado(UpdateGradoCommand request);
        Task<ActionResult<GradoViewModel>> DeleteGrado(int id);
        Task<ActionResult<GradoViewModel>> GetGradoById(int id);
        Task<ActionResult<IEnumerable<GradoViewModel>>> GetGradoList(GetGradoListQuery request);
    }
}
