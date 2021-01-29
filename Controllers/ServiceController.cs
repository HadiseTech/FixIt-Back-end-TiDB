using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using fixit.Data;
using fixit.DTO;
using Microsoft.AspNetCore.Mvc;
using fixit.Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IRepository<Service> _repo;
        private readonly IMapper _mapper;
        public ServiceController(IRepository<Service> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        
        [HttpGet("getAllServices")]
        public async Task<IActionResult> GetServices()
        {
            var model = await _repo.GetData();
            return Ok(_mapper.Map<IEnumerable<ServiceDto>>(model));
        }

        [HttpGet("getAllServiceById")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            
            var model = await _repo.GetDataById(id);
            return Ok(_mapper.Map<ServiceDto>(model));
        }

        [HttpPost("InsertService")]
        public async Task<IActionResult> CreateService(ServiceDto serviceDto)
        {
            
            var service = _mapper.Map<Service>(serviceDto);
            await _repo.UpdateData(service);
            return Ok(serviceDto);
        }

        [HttpDelete("deleteService")]
        public async Task<IActionResult> DeleteServices(ServiceDto serviceDto)
        {
            var service = _mapper.Map<Service>(serviceDto);
            await _repo.DeleteData(service);
            return Ok(serviceDto);

        }
     
     
     
     
     
     
     

     

    }
}