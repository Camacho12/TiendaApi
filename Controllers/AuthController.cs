using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Services;
using TIENDAAPI.Models;
using  TIENDAAPI.Dtos;

namespace TIENDAAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public AuthController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("register")]
        public async Task<IActionResult>Register(CrearUsuarioDto dto)
        {
            var usuario = await _usuarioService.CrearUsuarioAsync(dto);
            return Ok(new { usuario.Id, usuario.Email});
        }

        [HttpPost("login")]
        public async Task<IActionResult>Login(LoginDto dto)
        {
            var usuario = await _usuarioService.LoginAsync(dto);
            if(usuario == null)
                return Unauthorized();

            return Ok(new {usuario.Id, usuario.Email});

        }
    }
}