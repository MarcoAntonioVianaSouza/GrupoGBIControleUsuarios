using FluentAssertions;
using GrupoGBIControleUsuarios.Domain.Entities;

namespace GrupoGBIControleUsuarios.Domain.Tests
{
    public class UsuarioUnitTest1
    {
        [Fact(DisplayName = "Criando um usu�rio estado v�lido")]
        public void CriarUsuario_ComParametrosValidos_ResultadoValido()
        {
            Action action = () => new Usuario("UserNameoAte20Letras", "Jose", "Silva", "Senegal2026*", "email01@localhost", true);
            action.Should()
                .NotThrow <GrupoGBIControleUsuarios.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criando um cen�rio de erro onde nome do usu�rio (username) � menor que 10 caracteres")]
        public void CriarUsuario_ComParametrosInvalidoParaUserName_ResultadoInvalido()
        {
            Action action = () => new Usuario("5Letras", "Jose", "Silva", "Senegal2026*", "email01@localhost", true);
            action.Should().Throw<GrupoGBIControleUsuarios.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Quantidade de caracteres < 10 para nome do usu�rio");
                
        }

        [Fact(DisplayName = "Criando um cen�rio de erro onde e-mail n�o � informado")]
        public void CriarUsuario_ComParametrosInvalidoParaEmail_ResultadoInvalido()
        {
            Action action = () => new Usuario("5Letras", "Joao", "Silva", "TartarugasNinjas2*" ,"", true);
            action.Should().Throw<GrupoGBIControleUsuarios.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("E-Mail n�o informado");
        }
    }
}