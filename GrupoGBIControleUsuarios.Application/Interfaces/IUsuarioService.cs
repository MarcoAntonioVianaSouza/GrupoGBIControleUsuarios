using GrupoGBIControleUsuarios.Application.DTOs;

namespace GrupoGBIControleUsuarios.Application.Interfaces;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDTO>> ObterUsuarios();
    Task<UsuarioDTO> ObterPorId(int? id);
    Task Criar(UsuarioDTO categoryDto);
    Task Atualizar(UsuarioDTO categoryDto);
    Task Remover(int? id);
}
