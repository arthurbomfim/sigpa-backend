using Microsoft.AspNetCore.Mvc;
using SIGPA_Backend.Application.DTOs;
using SIGPA_Backend.Application.UseCases.CriarUsuario;

namespace SIGPA_Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ICriarUsuarioUseCase _criarUsuarioUseCase;

        public UsuarioController(ICriarUsuarioUseCase criarUsuarioUseCase)
        {
            _criarUsuarioUseCase = criarUsuarioUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarUsuarioRequest request)
        {
            try
            {
                var id = await _criarUsuarioUseCase.ExecutarAsync(request);
                return Ok(new { Id = id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }
    }
}