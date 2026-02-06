using AutoMapper;
using UsersManagment.Application.Common.DTOs.UserDTOs;
using UsersManagment.Domain.Entities;



namespace UsersManagment
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto> ().ReverseMap();
        }
    }
}
