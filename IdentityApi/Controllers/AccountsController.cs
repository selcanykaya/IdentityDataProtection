using IdentityApi.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    errors = ModelState.Values.SelectMany(x => x.Errors)
                                              .Select(y => y.ErrorMessage)
                });
            }

            var user = new IdentityUser
            {
                UserName = registerDto.Email,
                Email = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok(new { message = "Kayıt başarılı." });
            }

            return BadRequest(new
            {
                errors = result.Errors.Select(e => e.Description)
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { errors = ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage) });
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) 
            {
                return Unauthorized("Kullanıcı bulunamadı.");
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false , false);

            if (result.Succeeded)
                return Ok("Giriş başarılıyla gerçekleştirildi.");

            return Unauthorized("Email veya Şifre yanlış!");

        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = _userManager.Users.Select(x => new {x.Id, x.UserName, x.Email }).ToList();
            return Ok(users);
        }
    }
}
