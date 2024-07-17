using GrupoGBIControleUsuarios.API.Models;
using GrupoGBIControleUsuarios.Application.DTOs;
using GrupoGBIControleUsuarios.Application.Interfaces;
using GrupoGBIControleUsuarios.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GrupoGBIControleUsuarios.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly IConfiguration _configuration;

    public UsuarioController(IUsuarioService usuarioService, IConfiguration configuration)
    {
        _usuarioService = usuarioService;
        _configuration = configuration;
    }
   
    [HttpPost("LoginUser")]
    public ActionResult<UserToken> Login([FromBody] LoginModel userInfo)
    {
        var result = _usuarioService.AutenticarPorEmail(userInfo.Email, userInfo.Password);
        if (result != null)
        {
            return GenerateToken(userInfo);
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Login inválido");
            return BadRequest(ModelState);
        }
    }
    /// <summary>
    /// Adiciona um novo usuário no sistema.
    /// </summary>
    /// <param name="UsuarioDTO">Campos necessários para cadastrar um usuário.</param>
    /// <returns>ActionResult</returns>
    /// <response code="200">Caso a inserção seja realizada com sucesso.</response>

    [HttpPost("Usuario")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> CriarUsuario([FromBody] UsuarioDTO usuarioDto)
    {
        try
        {
            var novoUsuario = await _usuarioService.Criar(usuarioDto);
            //return Ok($"Usuário {novoUsuario.Email} foi criado com sucesso.");
            return CreatedAtAction(nameof(ObterUsuarioPorId),
            new { id = novoUsuario.Id },
            novoUsuario);

        }
        catch (Exception ex)
        {
            //TODO:Registrar Log
            ModelState.AddModelError(string.Empty, "Erro ao criar usuário.");
            return BadRequest(ModelState);
        }
    }

    /// <summary>
    /// Retorna uma lista de usuários cadastrados no sistema.
    /// </summary>
    /// <returns>ActionResult</returns>
    [HttpGet("Usuarios")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetUsuarios()
    {
        try
        {
            var usuarios = await _usuarioService.ObterUsuarios();

            if (usuarios == null)
                return NotFound("Não existem usuários cadastrados.");

            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Erro ao criar usuário.");
            return BadRequest(ModelState);
        }
    }

    /// <summary>
    /// Retornar um usuário específico.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>UsuarioDTO</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<UsuarioDTO>> ObterUsuarioPorId(int id)
    {
        var usuario = await _usuarioService.ObterPorId(id);
        if (usuario == null)
            return NotFound($"Usuário não encontrado com o id {id}.");

        return Ok(usuario);
    }

   /// <summary>
   /// Alterar usuário
   /// </summary>
   /// <returns>UsuarioDTO</returns>
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UsuarioDTO usuarioDto)
    {
      
        var usuarioAtualizado = await _usuarioService.Atualizar(usuarioDto);

        if (usuarioAtualizado == null)
            return BadRequest("Não foi possível atualizar registro do usuário.");
        else
            return Ok(usuarioAtualizado);
    }

    /// <summary>
    /// Excluir usuário
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(int id)
    {
        var usuario = await _usuarioService.ObterPorId(id);
        if (usuario == null)
            return NotFound($"Usuário não encontrado com o id {id}.");

        var usuarioRemovido = await _usuarioService.Remover(id);

        if (usuarioRemovido == null)
            return BadRequest("Erro ao excluir usuário.");

        return Ok("Usuário excluído com sucesso");
    }

    #region Geração Token para autenticação Jwt

    private UserToken GenerateToken(LoginModel userInfo)
    {
        // Declarações do usuário
        var claims = new[]
        {
            new Claim("email", userInfo.Email),
            new Claim("programador", "Marco Antonio Viana de Souza"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        //gerar a chave primada para assinar o token
        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

        //gerar assinatura digital
        var credencials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        //definir o tempo de expiração
        var expiration = DateTime.UtcNow.AddMinutes(10);

        //gerar o token
        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credencials);

        return new UserToken()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }

    #endregion
}
