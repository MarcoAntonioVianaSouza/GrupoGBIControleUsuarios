using FluentAssertions;
using GrupoGBIControleUsuarios.Domain.Entities;

namespace GrupoGBIControleUsuarios.Domain.Tests
{
    public class UsuarioUnitTest1
    {
        [Fact(DisplayName = "Criando um usuário estado válido")]
        public void CriarUsuario_ComParametrosValidos_ResultadoValido()
        {
            Action action = () => new Usuario("UserNameoAte20Letras", "Jose", "Silva", "Senegal2026*", "email01@localhost", true);
            action.Should()
                .NotThrow <GrupoGBIControleUsuarios.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criando um cenário de erro onde nome do usuário (username) é menor que 10 caracteres")]
        public void CriarUsuario_ComParametrosInvalidoParaUserName_ResultadoInvalido()
        {
            Action action = () => new Usuario("5Letras", "Jose", "Silva", "Senegal2026*", "email01@localhost", true);
            action.Should().Throw<GrupoGBIControleUsuarios.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Quantidade de caracteres < 10 para nome do usuário");
                
        }

        [Fact(DisplayName = "Criando um cenário de erro onde e-mail não é informado")]
        public void CriarUsuario_ComParametrosInvalidoParaEmail_ResultadoInvalido()
        {
            Action action = () => new Usuario("5Letras", "Joao", "Silva", "TartarugasNinjas2*" ,"", true);
            action.Should().Throw<GrupoGBIControleUsuarios.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-Mail não informado");
        }
    }
}