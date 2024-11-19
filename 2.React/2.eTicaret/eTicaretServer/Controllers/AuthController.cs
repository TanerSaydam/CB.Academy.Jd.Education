using eTicaretServer.Abstractions;
using eTicaretServer.Context;
using eTicaretServer.Dtos;
using eTicaretServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eTicaretServer.Controllers;
[AllowAnonymous]
public sealed class AuthController(
    ApplicationDbContext context,
    IOptions<JwtOptions> options
    ) : CommonApi
{
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto request, CancellationToken cancellationToken)
    {
        User? user = await context.Users.FirstOrDefaultAsync(p => p.UserName == request.UserName && p.Password == request.Password, cancellationToken);

        if (user is null)
        {
            return BadRequest(new { Message = "Kullanıcı bulunamadı" });
        }

        List<Claim> claims = new()
        {
            new Claim("Id", user.Id.ToString()),
            new Claim("Name", user.FullName),
            new Claim("UserName", user.UserName ?? "")
        };

        DateTime expires = DateTime.UtcNow.AddMonths(1);


        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey));

        JwtSecurityToken jwtSecurityToken = new(
            issuer: options.Value.Issuer,
            audience: options.Value.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expires,
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512));

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(jwtSecurityToken);

        return Ok(new { Token = token });
    }
}
