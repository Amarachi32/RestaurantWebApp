/*using Contracts.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IOptions<AppSettings> appSettings;
        private readonly IShare _share;
        private readonly IRepositoryV2<User> _userDataRepository;
        private readonly AppSettings _appSettings;

        public UserController(
            IUserRepository userRepository,
            IOptions<AppSettings> appSettings,
            IShare share,
            IRepositoryV2<User> userDataRepository)
        {
            _userRepository = userRepository;
            this.appSettings = appSettings;
            _share = share;
            _userDataRepository = userDataRepository;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(UserResponse), 200)]
        public async Task<IActionResult> Authenticate([FromBody] User userModel)
        {
            int userCount = _userDataRepository.Queryable.Where(u => u.Account == userModel.Account && u.Password == userModel.Password).Count();
            if (userCount > 0)
            {
                int userId = (await _userDataRepository.Queryable.Where(u => u.Account == userModel.Account && u.Password == userModel.Password).GetFirstOrDefaultAsync()).Id;
                User user = await _userRepository.GetUserByAccount(userId);
                if (user.Status.ToLower() == Constrants.USER_STATUS_ACTIVE)
                {
                    if (userModel.Account != user.Account || userModel.Password != user.Password)
                    {
                        return Unauthorized();
                    }

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim(ClaimTypes.Name, userModel.Account)
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(60),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    // return basic user info and token to store client side
                    return Ok(new UserResponse
                    {
                        UserId = user.Id,
                        UserName = user.Account,
                        Token = tokenString,
                        Role = user.Role
                    });
                }
                else
                {
                    return Ok(new UserResponse
                    {
                        UserName = "inactive",
                    });
                }
            }
            else
            {
                return Ok(new UserResponse
                {
                    UserName = "wrong",
                });
            }
        }

        [AllowAnonymous]
        [HttpGet("PasswordRecover")]
        [ProducesResponseType(typeof(UserResponse), 200)]
        public async Task<IActionResult> PasswordRecover(string email, int userId)
        {
            User userModel = await _userRepository.GetUserByAccount(userId);
            if (userModel.Status.ToLower() == Constrants.USER_STATUS_ACTIVE)
            {
                if (userModel.Id != userId)
                {
                    return Unauthorized();
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Email, userModel.Email)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                bool isUpdated = _share.SendEmail(_share.GetConfigKey("EmailFrom"), email, "Trojantrading Password Reset", string.Format("Click url below to reset password:\r\n\r\n{0}", "http://localhost:56410/recover/" + tokenString));
                // return basic user info and token to store client side
                return Ok(new UserResponse
                {
                    UserId = userModel.Id,
                    UserName = userModel.Account,
                    Token = tokenString
                });
            }
            else
            {
                return Ok(new UserResponse
                {
                    UserName = "",
                    Token = ""
                });
            }
        }

        [AllowAnonymous]
        [HttpGet("ValidateEmail")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        public async Task<IActionResult> ValidateEmail(string email)
        {
            var result = await _userRepository.ValidateEmail(email);
            return Ok(result);
        }
    }
}
*/