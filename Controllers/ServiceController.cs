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
    [Route("api/services")]
    public class ServiceController : ControllerBase
    {
        private readonly IRepository<Service> _repo;
        private readonly IMapper _mapper;
        public ServiceController(IRepository<Service> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            Console.WriteLine("This is the get All service method");

            var model = await _repo.GetData();
            // return Ok(_mapper.Map<IEnumerable<ServiceDto>>(model));
            return Ok(_mapper.Map<IEnumerable<ServiceDto>>(model));
            // return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
             Console.WriteLine("This is the comming id ");
            Console.WriteLine(id);
             

            var model = await _repo.GetDataById(id);
            return Ok(_mapper.Map<ServiceDto>(model));
        }
        // 
        // Get Service with different constraints
          [HttpGet("{pageNumber},{pageSize},{orderBy},{search}")]
        public async Task<IActionResult> GetServiceByConstraint(int pageNumber,int pageSize, string orderBy,string search)
        {   
            // ServiceRepository _service= new ServiceRepository();
             Console.WriteLine("These are the comming constriant");
             Console.WriteLine(pageNumber);
             Console.WriteLine(orderBy);
             Console.WriteLine(search);
       
           var model = await _repo.GetDataByConstraint(pageNumber,pageSize,orderBy,search);

        var totalPage= await _repo.GetTotalPage(pageSize,search);
        ServiceData service= new ServiceData(totalPage,model);
             
             
    // var totalRecords = await context.Customers.CountAsync();
    // return Ok(new PagedResponse<List<Customer>>(pagedData, validFilter.PageNumber, validFilter.PageSize));
            //  return Ok(_mapper.Map<ServiceDto>(model));
             return Ok(service);
        }
        // 
        // [Authorize(Roles = RoleEntity.Admin)]
        [HttpPost]
        public async Task<IActionResult> CreateService(ServiceDto serviceDto)
        {
            Console.WriteLine("Crate Service Method Invoked");
            var service = _mapper.Map<Service>(serviceDto);
            await _repo.UpdateData(service);
            return Ok(serviceDto);
        }
        
        // [Authorize(Roles = RoleEntity.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServices(int id)
        {
            var service = await _repo.GetDataById(id);
            // var service = _mapper.Map<Service>(serviceDto);
            await _repo.DeleteData(service);
            return Ok(_mapper.Map<ServiceDto>(service));

            // return Ok(serviceDto);
        }
    }
}