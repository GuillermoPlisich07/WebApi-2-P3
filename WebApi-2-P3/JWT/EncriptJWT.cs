using LogicaNegocio.Dominio;
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

            try {
                //var TokenString = "Encriptado_Password/Programacion3!WebApi12345678901234567890123456789012345678901234567890123456";
                //var TokenEncriptada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenString));
                //List<Claim> claims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Email, email),
                //    new Claim(ClaimTypes.Role, rol)
                //};

                //var credenciales = new SigningCredentials(TokenEncriptada, SecurityAlgorithms.HmacSha512Signature);

                //var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddHours(5), signingCredentials: credenciales);

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Obligatorio_2024_Primer/Semestre!Programacion3"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "tu_issuer",
                    audience: "tu_audience",
                    claims: new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, email),
                        new Claim(JwtRegisteredClaimNames.Sub, rol),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    },
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
