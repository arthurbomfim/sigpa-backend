using SIGPA_Backend.Domain.Enums;

namespace SIGPA_Backend.Domain.Entities;

public class Usuario
{
    public Guid Id { get; private set; }

    public string Nome { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string SenhaHash { get; private set; } = string.Empty;

    public Papel Papel { get; private set; }

    // Construtor principal (criação via regra de negócio)
    public Usuario(string nome, string email, string senhaHash, Papel papel)
    {
        Id = Guid.NewGuid();
        
        Validar(nome, email, senhaHash);

        Nome = nome;
        Email = email;
        SenhaHash = senhaHash;
        Papel = papel;
    }

    // Construtor vazio protegido (necessário para EF Core)
    protected Usuario() { }

    private void Validar(string nome, string email, string senhaHash)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome é obrigatório.");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email é obrigatório.");

        if (string.IsNullOrWhiteSpace(senhaHash))
            throw new ArgumentException("Senha é obrigatória.");
    }

    public void AlterarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome inválido.");

        Nome = nome;
    }

    public void AlterarSenha(string novaSenhaHash)
    {
        if (string.IsNullOrWhiteSpace(novaSenhaHash))
            throw new ArgumentException("Senha inválida.");

        SenhaHash = novaSenhaHash;
    }
}