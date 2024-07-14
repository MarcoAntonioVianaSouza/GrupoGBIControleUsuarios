using AutoMapper;
using GrupoGBIControleUsuarios.Domain.Entities;
using GrupoGBIControleUsuarios.Application.DTOs;

namespace GrupoGBIControleUsuarios.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
