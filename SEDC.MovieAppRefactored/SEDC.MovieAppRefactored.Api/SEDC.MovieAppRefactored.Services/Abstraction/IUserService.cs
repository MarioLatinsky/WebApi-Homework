using SEDC.MovieAppRefactored.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MovieAppRefactored.Services.Abstraction
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDTO registerUserDto);
        string LoginUser(LoginUserDTO loginUserDto);
    }
}
