using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NashBridge.Model;
using NashBridge.Repository.Interface;

namespace NashBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;


        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO requestDTO)
        {
            //check email
            var identityUser = await userManager.FindByEmailAsync(requestDTO.Email);
            if (identityUser != null)
            {
                //check password
                var checkPasswordResult = await userManager.CheckPasswordAsync(identityUser, requestDTO.Password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(identityUser);
                    //create a token and response
                    var token = tokenRepository.CreateJwtToken(identityUser, roles.ToList());
                    var response = new LoginResponse()
                    {
                        Email = requestDTO.Email,
                        Token = token
                    };
                    return Ok(response);
                }
            }

            ModelState.AddModelError("", "Email/Password is incorrect");

            return ValidationProblem(ModelState);

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO request)
        {


            var user = new IdentityUser
            {
                UserName = request.FirstName + request.LastName,
                Email = request.Email?.Trim(),
                PhoneNumber = request.PhoneNumber,
            };

             var identityResult = await userManager.CreateAsync(user, request.Password);

            if(identityResult.Succeeded)
            {
                identityResult= await userManager.AddToRoleAsync(user, "User");

                if(identityResult.Succeeded)
                {
                    return Ok(identityResult);
                }
                else
                {
                    if (identityResult.Errors.Any())
                    {
                        foreach (var error in identityResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }

            }
            else
            {
                if(identityResult.Errors.Any())
                {
                    foreach(var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return ValidationProblem(ModelState);
        }
    }
}
