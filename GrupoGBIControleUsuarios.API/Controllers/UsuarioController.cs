using GrupoGBIControleUsuarios.API.Models;
using GrupoGBIControleUsuarios.Application.DTOs;
using GrupoGBIControleUsuarios.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

    [HttpPost("Usuario")]
    public async Task<ActionResult> CriarUsuario([FromBody] UsuarioDTO novoUsuario)
    {
        try
        {
            await _usuarioService.Criar(novoUsuario);
            return Ok($"Usuário {novoUsuario.Email} foi criado com sucesso.");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Erro ao criar usuário.");
            return BadRequest(ModelState);
        }
    }

    /// <summary>
    /// Listar todos os usuários.
    /// </summary>
    /// <returns>Os usários cadastrados do sistema</returns>
    /// <response code="200">Retorna uma lista de usuários cadastrados</response>
    
    [HttpGet("Usuarios")]
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

    
    [HttpGet("{usuarioId:int}")]
    public async Task<ActionResult<UsuarioDTO>> Get(int usuarioId)
    {

        var user = await _usuarioService.ObterPorId(usuarioId);
        if (user == null)
            return NotFound($"Usuário não encontrado com o id {usuarioId}.");

        return Ok(user);
    }

    
    [HttpPut]
    public async Task<ActionResult> Update(UsuarioDTO usuarioDto)
    {
        if (usuarioDto == null)
            return BadRequest("Dados incorretos");

        var usuarioAtualizado = await _usuarioService.Atualizar(usuarioDto);

        if (usuarioAtualizado == null)
            return BadRequest("Não foi possível atualizar registro do usuário.");

        return Ok("Usuário atualizado com sucesso.");
    }

    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var user = await _usuarioService.Remover(id);

        if (user == null)
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
