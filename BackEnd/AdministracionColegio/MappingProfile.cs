using AdministracionColegio.CQRS.AlumnoGrados.ViewModel;
using AdministracionColegio.CQRS.Alumnos.ViewModel;
using AdministracionColegio.CQRS.Grados.ViewModel;
using AdministracionColegio.CQRS.Profesores.ViewModel;
using AdministracionColegio.Models;
using AutoMapper;

namespace AdministracionColegio
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Alumno, AlumnoViewModel>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.Nombre, b => b.MapFrom(c => c.Nombre))
                .ForMember(a => a.Apellidos, b => b.MapFrom(c => c.Apellidos))
                .ForMember(a => a.Genero, b => b.MapFrom(c => c.Genero))
                .ForMember(a => a.FechaNacimiento, b => b.MapFrom(c => c.FechaNacimiento));

            CreateMap<AlumnoGrado, AlumnoGradoViewModel>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.AlumnoId, b => b.MapFrom(c => c.AlumnoId))
                .ForMember(a => a.GradoId, b => b.MapFrom(c => c.GradoId))
                .ForMember(a => a.AlumnoNombre, b => b.MapFrom(c => $"{c.Alumno.Nombre} {c.Alumno.Apellidos}"))
                .ForMember(a => a.GradoNombre, b => b.MapFrom(c => c.Grado.Nombre))
                .ForMember(a => a.Seccion, b => b.MapFrom(c => c.Seccion));

            CreateMap<Grado, GradoViewModel>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.Nombre, b => b.MapFrom(c => c.Nombre))
                .ForMember(a => a.ProfesorId, b => b.MapFrom(c => c.ProfesorId))
                .ForMember(a => a.ProfesorNombre, b => b.MapFrom(c => $"{c.Profesor.Nombre} {c.Profesor.Apellidos}"));

            CreateMap<Profesor, ProfesorViewModel>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.Nombre, b => b.MapFrom(c => c.Nombre))
                .ForMember(a => a.Apellidos, b => b.MapFrom(c => c.Apellidos))
                .ForMember(a => a.Genero, b => b.MapFrom(c => c.Genero));
        }
    }
}
