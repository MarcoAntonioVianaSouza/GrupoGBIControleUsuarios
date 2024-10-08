﻿using GrupoGBIControleUsuarios.Domain.Entities;

namespace GrupoGBIControleUsuarios.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> ObterUsuarios();
    Task<Usuario> ObterPorId(int? id);
    Task<Usuario> Criar(Usuario usuario);
    Task<Usuario> Atualizar(Usuario usuario);
    Task<Usuario> Remover(Usuario usuario);
    Usuario? AutenticarUsuarioPorEmail(string email, string password);
}
