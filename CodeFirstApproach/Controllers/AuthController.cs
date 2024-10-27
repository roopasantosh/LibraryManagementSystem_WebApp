
using LibraryManagementProject.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;
    private readonly LibraryDbContext _context;

    public AuthController(JwtService jwtService, LibraryDbContext context)
    {
        _jwtService = jwtService;
        _context = context;
    }

    [HttpGet("login")]
    public async Task<IActionResult> LoginUser(string emailID, string password)
    {
        if (string.IsNullOrEmpty(emailID) || string.IsNullOrEmpty(password))
        {
            return BadRequest("invalid user details");
        }
        string encryptedPwd = PasswordHelper.HashPassword(password);
        var userResult = await _context.Users.Where(x => x.Email == emailID && x.Password == encryptedPwd).FirstOrDefaultAsync();

        if (userResult != null)
        {
            if (userResult.Email == emailID && userResult.Password == encryptedPwd)
            {
                var token = _jwtService.GenerateToken(userResult.Name, userResult.Email, userResult.Id,userResult.UserRole);
                return Ok(token);
            }
            return Unauthorized();
        }
        return BadRequest("InvalidUser/Password");
    }
}
