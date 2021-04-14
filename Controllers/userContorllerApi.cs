using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using fixit.Data;
using fixit.DTO;
using fixit.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using fixit.Entities;

using fixit.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Linq;
using Microsoft.Extensions.Options;

namespace Controllers
{

    // [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _jobRepository;
        private readonly IMapper _mapper;

        private List<User> registeredUsers;
        private readonly AppSettings _appSettings;

        public UserController(IRepository<User> repo, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _jobRepository = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;



        }

        private async void getUsers()
        {
            List<User> users = await _jobRepository.GetData();
            this.registeredUsers = users;
            Console.WriteLine("This is the GetUsers method and this the registered users", this.registeredUsers);
        }



        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            // var user = _userService.Authenticate(model.Username, model.Password);

            // if (user == null)
            //     return BadRequest(new { message = "Username or password is incorrect" });

            // return Ok(user);

            // 
            // getUsers();
            Console.WriteLine("Authentication Method");
            List<User> users = await _jobRepository.GetData();
            var user = users.SingleOrDefault(x => x.Email == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.UserId.ToString()),
                    // new Claim(ClaimTypes.Role, user.Role.RoleName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // user.Token = tokenHandler.WriteToken(token);
            UserEntity userEntity = new UserEntity();
            userEntity.user = user;
            userEntity.Token = tokenHandler.WriteToken(token);
            return Ok(userEntity);
        }
        // [Authorize(Roles = RoleEntity.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var model = await _jobRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(model));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            Console.WriteLine("Returning job of id" + id);
            var model = await _jobRepository.GetDataById(id);
            return Ok(_mapper.Map<UserDto>(model));
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            Console.WriteLine("Creating Users");
            var user = _mapper.Map<User>(userDto);
            await _jobRepository.UpdateData(user);
            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            Console.WriteLine("DELETE USER");
            var model = await _jobRepository.GetDataById(id);
            var user = _mapper.Map<User>(model);
            await _jobRepository.DeleteData(user);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDto user)
        {
            Console.WriteLine(user.FullName);
            var userModel = _mapper.Map<User>(user);
            await _jobRepository.UpdateData(userModel);
            return Ok(userModel);
        }
    }

}