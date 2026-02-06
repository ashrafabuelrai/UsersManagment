using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UsersManagment.Application.Common.DTOs.UserDTOs;
using UsersManagment.Application.Common.Responses;
using UsersManagment.Application.Services.Interfaces;

namespace UsersManagment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private ApiResponse _apiResponse;
        public UserController(IUserService userService)
        {
            _userService = userService;
            _apiResponse = new ApiResponse();

        }
        [HttpPost("CreatUser")]
        public async Task<ActionResult<ApiResponse>> Create([FromForm] CreateUserDto createUserDto)
        {
            if (createUserDto is null)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_apiResponse);
            }
            var result = await _userService.CreateUser(createUserDto);
            if (result == null)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.ErrorMessage.Add("Failed to create user.");
                return BadRequest(_apiResponse);
            }
            _apiResponse.IsSuccess = true;
            _apiResponse.StatusCode = HttpStatusCode.Created;
            _apiResponse.Result = result;
            return Ok(_apiResponse);

        }
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            var result = await _userService.GetAllUsers();
            if (result == null||result.Count()==0)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.StatusCode = HttpStatusCode.NotFound;
                _apiResponse.ErrorMessage=new List<string> { "No users found." };
                return NotFound(_apiResponse);
            }
            _apiResponse.IsSuccess = true;
            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.Result = result;
            return Ok(_apiResponse);
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<ApiResponse>> GetById(Guid id)
        {
            var result = await _userService.GetUserById(id);
            if (result == null)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.StatusCode = HttpStatusCode.NotFound;
                _apiResponse.ErrorMessage=new List<string> { "User not found." };
                return NotFound(_apiResponse);
            }
            _apiResponse.IsSuccess = true;
            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.Result = result;
            return Ok(_apiResponse);
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.StatusCode = HttpStatusCode.NotFound;
                _apiResponse.ErrorMessage.Add("User not found.");
                return NotFound(_apiResponse);
            }
            await _userService.DeleteUser(id);
            _apiResponse.IsSuccess = true;
            _apiResponse.StatusCode = HttpStatusCode.NoContent;
            return NoContent();
        }
    }
}
