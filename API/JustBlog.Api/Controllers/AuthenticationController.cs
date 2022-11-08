using JustBlog.Entities.Entities;
using JustBlog.Model.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JustBlog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IConfiguration configuration;
    private readonly RoleManager<IdentityRole<Guid>> roleManager;
    public AuthenticationController(UserManager<ApplicationUser> userManager, IConfiguration configuration, RoleManager<IdentityRole<Guid>> roleManager)
    {
        this.userManager = userManager;
        this.configuration = configuration;
        this.roleManager = roleManager;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<string>> Login([FromBody] Login login)
    {

        ApplicationUser? user = await userManager.FindByEmailAsync(login.UserName);
        if (user == null)
        {
            return BadRequest("Invalid username or password");
        }
        bool isUser = await userManager.CheckPasswordAsync(user, login.Password);
        if (isUser != true)
        {
            return BadRequest("Invalid username or password");
        }

        string role = (await userManager.GetRolesAsync(user))[0];



        byte[] key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
        string? audience = configuration["Jwt:Audience"];
        string? issuer = configuration["Jwt:Issuer"];
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Sid, user.Id.ToString())
            }),

            //Expires = DateTime.UtcNow.AddHours(expireTime),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
            Issuer = issuer,
            Audience = audience,
            Expires = login.Remember == true ? DateTime.UtcNow.AddYears(20) : DateTime.UtcNow.AddHours(1)
        };
        JwtSecurityTokenHandler tokenHandler = new();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        string tokenString = tokenHandler.WriteToken(token);

        return Ok(new { Token = tokenString });

    }

    [HttpPost("Register")]
    public async Task<ActionResult> Register([FromBody] Register register)
    {
        if (register.Password != register.PasswordConfirm)
        {
            return BadRequest();
        }
        ApplicationUser user = new()
        {
            UserName = register.Email,
            Email = register.Email,
            NormalizedEmail = register.Email.ToUpper(),
            NormalizedUserName = register.Email.ToUpper(),
            SecurityStamp = string.Empty,
            LockoutEnabled = false,

        };
        //roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
        IdentityResult result = await userManager.CreateAsync(user, register.Password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "User");
            return Ok();
        }
        return BadRequest();
    }
}
