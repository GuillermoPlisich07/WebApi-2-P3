using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi_2_P3.JWT
{
    public class EncriptJWT
    {
        public static string GenerarToken(string email, string rol)
        {
            var TokenString = "Encriptado_Password/Programacion3!WebApi";
            var TokenEncriptada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenString));
            List<Claim> claims = [
                                    new Claim(ClaimTypes.Email, email),
                                    new Claim(ClaimTypes.Role, rol)
                                 ];

            var credenciales = new SigningCredentials(TokenEncriptada, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddHours(5), signingCredentials: credenciales);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
