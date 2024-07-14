using GrupoGBIControleUsuarios.Domain.Validation;

namespace GrupoGBIControleUsuarios.Domain.Entities;

public sealed class Usuario : Entity
{
    public string NomeDeUsuario { get; private set; }
    public string Nome { get; private set; }
    public string Sobrenome { get; private set; }
    public string Senha { get; private set; }
    public string Email { get; private set; }
    public bool EAdministrador { get; private set; }
    //public bool EBloqueada { get; private set; }
    //public byte QuantidadeDeTentativasIncorretas { get; private set; }

    
     //public Usuario(int id, string name)
    //{
    //    DomainExceptionValidation.When(id < 0, "Invalid Id value");
    //    Id = id;
    //    ValidateDomain(name);
    //}

    public Usuario(string nomeDeUsuario, string nome, string sobrenome, string senha, string email, bool eAdministrador)
    {
        NomeDeUsuario = nomeDeUsuario;
        Nome = nome;
        Sobrenome = sobrenome;
        Senha = senha;
        Email = email;
        EAdministrador = eAdministrador;
    }

    public Usuario(int id, string nomeDeUsuario, string nome, string sobrenome, string senha, string email, bool eAdministrador)
    {
        DomainExceptionValidation.When(id < 0, "ID inválido");
        Id = id;
        ValidateDomain(nomeDeUsuario, nome, sobrenome, senha, email, eAdministrador);

        NomeDeUsuario = nomeDeUsuario;
        Nome = nome;
        Sobrenome = sobrenome;
        Senha = senha;
        Email = email;
        EAdministrador = eAdministrador;
    }

    public void Update(string nomeDeUsuario, string nome, string sobrenome, string senha, string email, bool eAdministrador)
    {
        ValidateDomain(nomeDeUsuario, nome, sobrenome, senha, email, eAdministrador);
    }

    private void ValidateDomain(string nomeDeUsuario, string nome, string sobrenome, string senha, string email, bool eAdministrador)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nomeDeUsuario), "Informar um nome de usuário para a conta.");
        DomainExceptionValidation.When(nomeDeUsuario.Length < 6, "Nome de usuário de conta muito curto, mínimo de 6 caracteres.");
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Informar o nome do usuário da conta.");
        DomainExceptionValidation.When(string.IsNullOrEmpty(sobrenome), "Informar o sobrenome do usuário da conta.");
        DomainExceptionValidation.When(string.IsNullOrEmpty(senha), "Senha não incormado.");
        DomainExceptionValidation.When(senha.Length < 8, "Nome de usuário de conta muito curto, mínimo de 8 caracteres.");
        DomainExceptionValidation.When(string.IsNullOrEmpty(email), "E-mail não informado.");

        NomeDeUsuario = nomeDeUsuario;
        Nome = nome;
        Sobrenome = sobrenome;
        Senha = senha;
        Email = email;
        EAdministrador = eAdministrador;
    }
}
