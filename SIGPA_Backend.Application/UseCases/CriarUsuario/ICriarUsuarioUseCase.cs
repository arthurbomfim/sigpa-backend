using SIGPA_Backend.Application.DTOs;

namespace SIGPA_Backend.Application.UseCases.CriarUsuario;

public interface ICriarUsuarioUseCase
{
    Task<Guid> ExecutarAsync(CriarUsuarioRequest request);
}