using AutoMapper;
using GrupoGBIControleUsuarios.Application.DTOs;
using GrupoGBIControleUsuarios.Application.Interfaces;
using GrupoGBIControleUsuarios.Domain.Entities;
using GrupoGBIControleUsuarios.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoGBIControleUsuarios.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, 
                                IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> ObterUsuarios()
        {
            var usuarios = await _usuarioRepository.ObterUsuarios();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }

        public async Task<UsuarioDTO> ObterPorId(int? id)
        {
            var usuarioEntity = await _usuarioRepository.ObterPorId(id);
            return _mapper.Map<UsuarioDTO>(usuarioEntity);
        }

        public async Task<UsuarioDTO> Criar(UsuarioDTO usuarioDto)
        {
            // TODO:IMPLEMENTAR SEGURANÇA (CRIPOGRAFIA)
            var usuarioEntity = _mapper.Map<Usuario>(usuarioDto);
            var novoUsuario = await _usuarioRepository.Criar(usuarioEntity);
            return _mapper.Map<UsuarioDTO>(novoUsuario);
        }

        public async Task<UsuarioDTO> Atualizar(UsuarioDTO usuarioDto)
        {
            var usuarioEntity = _mapper.Map<Usuario>(usuarioDto);
            var usuarioAtualizado = await _usuarioRepository.Atualizar(usuarioEntity);
            return _mapper.Map<UsuarioDTO>(usuarioAtualizado);
        }

        public async Task<UsuarioDTO> Remover(int? id)
        {
            var usuarioEntity = _usuarioRepository.ObterPorId(id).Result;
            var usuarioExcluido =  await _usuarioRepository.Remover(usuarioEntity);
            return _mapper.Map<UsuarioDTO>(usuarioExcluido);
        }

        public Usuario? AutenticarPorEmail(string email, string senha)
        {
            return _usuarioRepository.AutenticarUsuarioPorEmail(email, senha);
        }
    }
}
