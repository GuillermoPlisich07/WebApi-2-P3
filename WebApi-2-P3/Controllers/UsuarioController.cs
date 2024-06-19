using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi_2_P3.JWT;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_2_P3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public ICULogin<DTOUsuario> CULogin { get; set; }

        public UsuarioController(ICULogin<DTOUsuario> cULogin)
        {
            CULogin = cULogin;
        }

        // POST api/<UsuarioController>
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] DTOLogin usr)
        {
            if (usr.email.IsNullOrEmpty()) return BadRequest("El campo Email no puede ser vacio.");
            if (usr.password.IsNullOrEmpty()) return BadRequest("El campo Password no puede ser vacio.");
            try
            {
                var usuario = CULogin.loguearse(usr.email,usr.password);
                if(usuario == null) return Unauthorized("Credenciales Incorrectas");
                string token = EncriptJWT.GenerarToken(usuario.Email, usuario.rol.nombre);
                return Ok(new { Token = token, Rol = usuario.rol.nombre, Email = usuario.Email });
            }
            catch (Exception ex)
            {
                return Unauthorized(new {Error = "Credenciales Incorrectas" });
            }
        }

        
    }
}
