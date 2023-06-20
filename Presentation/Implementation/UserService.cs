using AutoMapper;
using Contracts.DTOs;
using Contracts.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presentation.Interfaces;
using Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Implementation
{
    public class UserService: IUserService
    {
        private readonly IShare _share;
        private readonly UserManager<User> _userManager;
       // private readonly IValidator<UpdateRequest> _validator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IRepositoryV2<User> _userRepository;
        private IMapper _mapper;

        public UserService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, IMapper mapper, IShare share)
        {
            _userManager= userManager;
            _httpContextAccessor = httpContextAccessor;
            _share= share;
            _mapper = mapper;
        }

    /*    public async Task<ApiResponse> AddUser(User user)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(_share.RandomString(4, true));
                builder.Append(_share.RandomNumber(1000, 9999));
                builder.Append(_share.RandomString(2, false));
                user.Password = builder.ToString();
                _userRepository.Create(user);
                await _userRepository.SaveChangesAsync();
                return new ApiResponse()
                {
                    Status = "success",
                    Message = "Successfully add user"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }

        }
*/
       /* public async Task<ApiResponse> DeleteUser(int id)
        {
            try
            {
                var user = await _userRepository.Queryable.Where(u => u.Id == id).GetFirstOrDefaultAsync();
                user.Status = Constrants.USER_STATUS_INACTIVE;
                _userRepository.Update(user);
                await _userRepository.SaveChangesAsync();
                return new ApiResponse()
                {
                    Status = "success",
                    Message = "Successfully delete user"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }
        }
        */
        public async Task<ApiResponse> DeleteAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                user.Status = Constrants.USER_STATUS_INACTIVE;
                var result = await _userManager.UpdateAsync(user);
                return new ApiResponse()
                {
                    Status = "success",
                    Message = "Successfully delete user"
                };
            }

             catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }

        }

      /*  public async Task<User> GetUserByAccount(int userId)
        {
            var user = await _userRepository.Queryable.Where(u => u.Id == userId).GetFirstOrDefaultAsync();
            return user;
        }*/
        public async Task<User> GetUserByIdAsync(string userId)
        {
            var userfetch = await _userManager.FindByIdAsync(userId);

            if (userfetch == null) throw new KeyNotFoundException("User not found");
          //  var user = _mapper.Map<UserDto>(userfetch);

            return userfetch;
        }

     /*   public async Task<List<User>> GetUsers()
        {
            var users = await _userRepository.Queryable.GetListAsync();
            return users;
        }*/
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }
        
        
/*        public async Task<ApiResponse> Update(User user)
        {
            try
            {
                _userRepository.Update(user);
                await _userRepository.SaveChangesAsync();
                return new ApiResponse()
                {
                    Status = "success",
                    Message = "Successfully update user"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }
        }
        
*/        
        
     /*   public async Task<bool> UpdateUserAsync(string id, UpdateRequest model)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                throw new ArgumentException($"User not found");
            }
            var updatedUser = _mapper.Map(model, user);

            var result = await _userManager.UpdateAsync(updatedUser);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Failed to update user detail");
            }

            return result.Succeeded;
        }
*/

/*        public async Task<ApiResponse> UpdatePassword(int userId, string newPassword)
        {
            try
            {
                User user = await _userRepository.Queryable.Where(item => item.Id == userId).GetFirstOrDefaultAsync();
                user.Password = newPassword;
                _userRepository.Update(user);
                await _userRepository.SaveChangesAsync();

                return new ApiResponse()
                {
                    Status = "success",
                    Message = "Successfully update the password"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse> ValidateEmail(string email)
        {
            try
            {
                string userName = (await _userRepository.Queryable.Where(user => user.Email == email).GetFirstOrDefaultAsync()).Account;
                if (!string.IsNullOrEmpty(userName))
                {
                    return new ApiResponse()
                    {
                        Status = "success",
                        Message = "Email Address is Valid"
                    };
                }
                else
                {
                    return new ApiResponse()
                    {
                        Status = "fail",
                        Message = "This email address is not register in our website"
                    };
                }

            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse> ValidatePassword(int userId, string password)
        {
            try
            {
                var userModel = await _userRepository.Queryable.Where(user => user.Id == userId).GetFirstOrDefaultAsync();
                if (userModel.Password == password)
                {
                    return new ApiResponse()
                    {
                        Status = "success",
                        Message = "Successfully validate your password"
                    };
                }
                else
                {
                    return new ApiResponse()
                    {
                        Status = "fail",
                        Message = "Please input validate password"
                    };
                }

            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Status = "fail",
                    Message = ex.Message
                };
            }
        }

        private string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }*/

    }
}
