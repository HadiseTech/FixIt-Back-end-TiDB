using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using fixit.Data;
using fixit.DTO;
using Microsoft.AspNetCore.Mvc;
using fixit.Models;
using fixit.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Controllers
{

    // [Authorize]
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRepository<Role> _repo;
        private readonly IMapper _mapper;
        public RoleController(IRepository<Role> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            Console.WriteLine("This is the get All role method");

            var model = await _repo.GetData();
            // return Ok(_mapper.Map<IEnumerable<RoleDto>>(model));
            return Ok(_mapper.Map<IEnumerable<RoleDto>>(model));
            // return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {

            Console.WriteLine("This is the get all role by id method");

            var model = await _repo.GetDataById(id);
            return Ok(_mapper.Map<RoleDto>(model));
        }
        // [Authorize(Roles = RoleEntity.Admin)]
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleDto serviceDto)
        {

            var role = _mapper.Map<Role>(serviceDto);
            await _repo.UpdateData(role);
            return Ok(serviceDto);
        }

        // [Authorize(Roles = RoleEntity.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoles(int id)
        {
            var role = await _repo.GetDataById(id);
            // var role = _mapper.Map<Role>(serviceDto);
            await _repo.DeleteData(role);
            return Ok(_mapper.Map<RoleDto>(role));

            // return Ok(serviceDto);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(int id,RoleDto role)
        {
           var roleModel = _mapper.Map<Role>(role);
            await _repo.UpdateData(roleModel);
            return Ok(roleModel);

        }










    }
}