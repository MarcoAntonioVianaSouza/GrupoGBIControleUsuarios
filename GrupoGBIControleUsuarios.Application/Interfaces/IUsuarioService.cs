using GrupoGBIControleUsuarios.Application.DTOs;
using GrupoGBIControleUsuarios.Domain.Entities;

namespace GrupoGBIControleUsuarios.Application.Interfaces;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDTO>> ObterUsuarios();
    Task<UsuarioDTO> ObterPorId(int? id);
    Task<UsuarioDTO> Criar(UsuarioDTO usuarioDto);
    Task<UsuarioDTO> Atualizar(UsuarioDTO usuarioDto);
    Task<UsuarioDTO> Remover(int? id);
    Usuario? AutenticarPorEmail(string email, string password);
}

