using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManagment.Application.Common.DTOs.UserDTOs;
using UsersManagment.Application.Services.Interfaces;
using UsersManagment.Domain.Entities;
using UsersManagment.infrastructure.Repositrories.Interfaces;

namespace UsersManagment.Application.Services.Implemention
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
         }
        public async Task<UserDto> CreateUser(CreateUserDto createUserDto)
        {
            User user = _mapper.Map<User>(createUserDto);
            user.Id = Guid.NewGuid();
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Save();
            return _mapper.Map<UserDto>(user);
        }

        public async Task DeleteUser(Guid id)
        {
            var user = await _unitOfWork.UserRepository.Get(u=>u.Id==id);
            _unitOfWork.UserRepository.Remove(user);
            _unitOfWork.Save();
            
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers(int pageSize = 0, int pageNumber = 1)
        {
            return _mapper.Map<IEnumerable<UserDto>>( await _unitOfWork.UserRepository.GetAll(null,"",pageSize, pageNumber));
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            return _mapper.Map<UserDto>(await _unitOfWork.UserRepository.Get(u => u.Id == id));
        }

        public async Task UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var user = await _unitOfWork.UserRepository.Get(u => u.Id == id);
            user.FullName = updateUserDto.FullName;
            user.Email = updateUserDto.Email;
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Save();
        }
    }
}
