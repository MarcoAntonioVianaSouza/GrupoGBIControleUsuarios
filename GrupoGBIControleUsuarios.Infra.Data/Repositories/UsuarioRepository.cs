using GrupoGBIControleUsuarios.Domain.Entities;
using GrupoGBIControleUsuarios.Domain.Interfaces;
using GrupoGBIControleUsuarios.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoGBIControleUsuarios.Infra.Data.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private ApplicationDbContext _usuarioContext;
    public UsuarioRepository(ApplicationDbContext context)
    {
        _usuarioContext = context;
    }

    public async Task<Usuario> Criar(Usuario usuario)
    {
        _usuarioContext.Add(usuario);
        await _usuarioContext.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> ObterPorId(int? id)
    {
        return await _usuarioContext.Usuarios.FindAsync(id);
    }

    public async Task<IEnumerable<Usuario>> ObterUsuarios()
    {
        return await _usuarioContext.Usuarios.ToListAsync();
    }

    public async Task<Usuario> Remover(Usuario usuario)
    {
        _usuarioContext.Remove(usuario);
        await _usuarioContext.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> Atualizar(Usuario usuario)
    {
        _usuarioContext.Update(usuario);
        await _usuarioContext.SaveChangesAsync();
        return usuario;
    }

    public Usuario? AutenticarUsuarioPorEmail(string email, string senha)
    {
         return _usuarioContext.Usuarios.Where(u => u.Email.Equals(email)).FirstOrDefault();
    }


}
