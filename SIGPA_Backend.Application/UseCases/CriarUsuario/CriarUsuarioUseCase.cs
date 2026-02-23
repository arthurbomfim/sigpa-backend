using SIGPA_Backend.Application.DTOs;
using SIGPA_Backend.Application.Interfaces;
using SIGPA_Backend.Domain.Entities;
using SIGPA_Backend.Domain.Interfaces;

namespace SIGPA_Backend.Application.UseCases.CriarUsuario;

public class CriarUsuarioUseCase : ICriarUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ISenhaHasher _senhaHasher;

    public CriarUsuarioUseCase(
        IUsuarioRepository usuarioRepository,
        ISenhaHasher senhaHasher)
    {
        _usuarioRepository = usuarioRepository;
        _senhaHasher = senhaHasher;
    }

    public async Task<Guid> ExecutarAsync(CriarUsuarioRequest request)
    {
        // 1️⃣ Verificar se email já existe
        var usuarioExistente = await _usuarioRepository
            .ObterPorEmailAsync(request.Email);

        if (usuarioExistente != null)
            throw new Exception("Já existe um usuário com esse email.");

        // 2️⃣ Gerar hash da senha
        var senhaHash = _senhaHasher.Hash(request.Senha);

        // 3️⃣ Criar entidade
        var usuario = new Usuario(
            request.Nome,
            request.Email,
            senhaHash,
            request.Papel
        );

        // 4️⃣ Salvar
        await _usuarioRepository.AdicionarAsync(usuario);

        // 5️⃣ Retornar Id
        return usuario.Id;
    }
}