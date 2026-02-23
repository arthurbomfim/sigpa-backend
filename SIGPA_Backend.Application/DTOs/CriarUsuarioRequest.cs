using SIGPA_Backend.Domain.Enums;

namespace SIGPA_Backend.Application.DTOs;

public class CriarUsuarioRequest
{
    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Senha { get; set; } = string.Empty;

    public Papel Papel { get; set; }
}