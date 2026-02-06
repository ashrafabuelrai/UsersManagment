using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManagment.Application.Common.DTOs.UserDTOs;

namespace UsersManagment.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUser(CreateUserDto createUserDto);
        Task<IEnumerable<UserDto>> GetAllUsers(int pageSize = 0, int pageNumber = 1);
        Task<UserDto> GetUserById(Guid id);
        Task UpdateUser(Guid id, UpdateUserDto updateUserDto);
        Task DeleteUser(Guid id);
        
    }
}
