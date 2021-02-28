using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using fixit.Data;
using fixit.DTO;
using fixit.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Controllers
{

    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _jobRepository;
        private readonly IMapper _mapper;
        public UserController(IRepository<User> repo, IMapper mapper)
        {
            _jobRepository = repo;
            _mapper = mapper;
        }
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
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            Console.WriteLine("Creating Job");
            var user = _mapper.Map<User>(userDto);
            await _jobRepository.UpdateData(user);
            return Ok(userDto);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUser(int id)
        {
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