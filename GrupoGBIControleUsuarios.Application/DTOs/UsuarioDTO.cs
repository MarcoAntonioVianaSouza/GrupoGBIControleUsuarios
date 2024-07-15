using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GrupoGBIControleUsuarios.Application.DTOs;

public class UsuarioDTO
{
    public int Id { get; set; }
        
    [Required(ErrorMessage = "Um nome de usuário (username) é obrigatório")]
    [MinLength(10)]
    [MaxLength(20)]
    public string NomeDeUsuario { get; set; }
    
    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(2)]
    [MaxLength(50)]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O sobrenome é obrigatório")]
    [MinLength(2)]
    [MaxLength(50)]
    public string Sobrenome { get; set; }
    public string Senha { get; set; }
    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [MinLength(10)]
    [MaxLength(100)]
    public string Email { get;  set; }
    [Required]
    public bool EAdministrador { get; set; }
}
