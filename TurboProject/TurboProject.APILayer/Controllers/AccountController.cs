using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TurboProject.BusinessLayer.Model.ApiResponse;
using TurboProject.BusinessLayer.Model.DTO.Request.Account;
using TurboProject.BusinessLayer.Model.DTO.Response.Account;
using TurboProject.BusinessLayer.Service.Interface;
using TurboProject.DataLayer.Entity;

namespace TurboProject.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IJWTService jWTService;
        private readonly IMapper mapper;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IJWTService jWTService, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jWTService = jWTService;
            this.mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
        {
            var response = new ApiResponse<string>();
            if (!ModelState.IsValid)
            {
                response.Error(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());
                return BadRequest(response);
            }
            if (model.Password != model.ConfirmPassword)
            {
                response.Error("Passwords do not match");
                return BadRequest(response);
            }
            var existingUser = await userManager.FindByEmailAsync(model.Email);

            if (existingUser != null)
            {
                response.Error("User with this email already exists");
                return BadRequest(response);
            }

            var user = mapper.Map<User>(model);
            var result = await userManager.CreateAsync(user, model.Password);
            await userManager.AddToRoleAsync(user, "User");
            if (!result.Succeeded)
            {
                response.Error(result.Errors.Select(s => s.Description).ToList());
                return BadRequest(response);
            }
            response.Success("User registered successfully");
            return Ok(response);

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var response = new ApiResponse<LoginResponseDto>();

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                response.Error("Incorrect email or password");
                return Unauthorized(response);
            }

            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                response.Error("Incorrect email or password");
                return Unauthorized(response);
            }

            var roles = await userManager.GetRolesAsync(user);
            var token = jWTService.GenerateToken(user, roles.ToList());

            response.Success(new LoginResponseDto
            {
                Token = token,
                Email = user.Email,
                Roles = roles.ToList()
            });

            return Ok(response);
        }

        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            var response = new ApiResponse<string>();
            await signInManager.SignOutAsync();
            response.Success("you are logged out");
            return Ok(response);
        }
    }
}
