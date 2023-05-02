using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using GymnasioEticBack.Models;

namespace GymnasioEticBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {


        private readonly NewGymEtitcContext _context;

        public AuthController(NewGymEtitcContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(Usuario usuario)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == usuario.Correo && u.Contraseña == usuario.Contraseña);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = GenerateToken(user.IdUsuario);

            return Ok(new { token });
        }

        private string GenerateToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("W$k+&94#xHJZ^vQ8B!M#L9%aP6@dYfE\r\n"); // Debes reemplazar esto con tu propia clave secreta.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("userId", userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(3), // Cambia Expires a la hora actual más 3 horas
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}