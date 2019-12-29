using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Backend.Distribucion.Autenticacion
{
    public class Autenticacion
    {
        private readonly IConfiguration _configuration;
        public Autenticacion(IConfiguration configurationParameter)
        {
            _configuration = configurationParameter;
        }
        public string GenerarToken()
        {
            var loJwtHeader = ObtenerJWTHeader();
            var loClaimsSesion = ObtenerClaimsSesion();
            var loJwtPayload = ObtnerJWTPayload(loClaimsSesion);

            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken
                (loJwtHeader, loJwtPayload)
            );
        }
        #region Metodos privados
        private JwtHeader ObtenerJWTHeader()
        {
            var loLlaveSeguridad = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["ConfiguracionToken:ClaveSecreta"])
                );
            var loCredencialFirmada = new SigningCredentials(
                    loLlaveSeguridad, SecurityAlgorithms.HmacSha256
                );
            var loJwtHeader = new JwtHeader(loCredencialFirmada);
            return loJwtHeader;
        }
        private List<Claim> ObtenerClaimsSesion()
        {
            var loClaimsSession = new List<Claim>();
            loClaimsSession.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            loClaimsSession.Add(new Claim("Usuario", "LuisEdMB"));
            loClaimsSession.Add(new Claim(ClaimTypes.Role, "ADMIN"));
            return loClaimsSession;
        }
        private JwtPayload ObtnerJWTPayload(List<Claim> aoClaimsSesion)
        {
            return new JwtPayload(
                issuer: _configuration["ConfiguracionToken:Issuer"],
                audience: _configuration["ConfiguracionToken:AudienciaPermitida"],
                claims: aoClaimsSesion,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(5)
            );
        }
        #endregion
    }
}
