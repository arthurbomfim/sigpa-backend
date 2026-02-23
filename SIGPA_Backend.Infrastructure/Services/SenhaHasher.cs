using Microsoft.AspNetCore.Identity;
using SIGPA_Backend.Application.Interfaces;

namespace SIGPA_Backend.Infrastructure.Services;

public class SenhaHasher : ISenhaHasher
{
    private readonly PasswordHasher<object> _hasher;

    public SenhaHasher()
    {
        _hasher = new PasswordHasher<object>();
    }

    public string Hash(string senha) => _hasher.HashPassword(null, senha);

    public bool Verificar(string senha, string hash) =>
        _hasher.VerifyHashedPassword(null, hash, senha) == PasswordVerificationResult.Success;
}