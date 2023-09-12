using SEDC.MovieAppRefactored.CustomExceptions;
using SEDC.MovieAppRefactored.DataAccess.Abstraction;
using SEDC.MovieAppRefactored.DTOs.UserDTOs;
using SEDC.MovieAppRefactored.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MovieAppRefactored.Services.Implementation
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string LoginUser(LoginUserDTO loginUserDto)
        {
            if (string.IsNullOrEmpty(loginUserDto.Username) ||
              (string.IsNullOrEmpty(loginUserDto.Password)))
            {
                throw new UserDataException("Username and Password fields cannot be empty.");
            }

            var userFromDb  = _userRepository.LoginUser(loginUserDto.Username, StringHasher)
        }

        public void RegisterUser(RegisterUserDTO registerUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
