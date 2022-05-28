using MeetupTime.API.Entities;
using MeetupTime.API.Identity;
using MeetupTime.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetupTime.API.Controllers;

[Route("api/account")]
public class AccountController : ControllerBase
{
    private readonly Context _context;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public AccountController(Context context, IPasswordHasher<User> passwordHasher, IJwtProvider jwtProvider)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody]UserLoginDto model)
    {
        var user = _context.Users
            .Include(x => x.Role)
            .FirstOrDefault(x => x.Email == model.Email);

        if (model == null)
        {
            return BadRequest("Invalid username or password");
        }

        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
        
        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            return BadRequest("Invalid username or password");
        }

        var token = _jwtProvider.GenerateJwtToken(user);

        return Ok(token);
    }

    [HttpPost("register")]
    public ActionResult Register([FromBody] RegisterUserDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newUser = new User
        {
            Email = model.Email,
            Nationality = model.Nationality,
            DateOfBirth = model.DateOfBirth,
            RoleId = model.RoleId
        };

        var passwordHash = _passwordHasher.HashPassword(newUser, model.Password);
        newUser.PasswordHash = passwordHash;

        _context.Users.Add(newUser);
        _context.SaveChanges();

        return Ok();
    }
}
