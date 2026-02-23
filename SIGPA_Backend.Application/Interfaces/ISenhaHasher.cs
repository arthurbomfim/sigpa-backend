namespace SIGPA_Backend.Application.Interfaces;

public interface ISenhaHasher
{
    string Hash(string senha);

    bool Verificar(string senha, string hash);
}