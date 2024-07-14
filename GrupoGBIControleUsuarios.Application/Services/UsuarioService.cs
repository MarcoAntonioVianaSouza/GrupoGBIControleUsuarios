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

        public async Task Criar(UsuarioDTO usuarioDto)
        {
            var usuarioEntity = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioRepository.Criar(usuarioEntity);
        }

        public async Task Atualizar(UsuarioDTO usuarioDto)
        {
            var usuarioEntity = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioRepository.Atualizar(usuarioEntity);
        }

        public async Task Remover(int? id)
        {
            var usuarioEntity = _usuarioRepository.ObterPorId(id).Result;
            await _usuarioRepository.Remover(usuarioEntity);
        }
    }
}
