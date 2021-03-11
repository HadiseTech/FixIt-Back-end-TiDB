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

    [Route("api/technicians")]
    [ApiController]
    public class TechnicianController : ControllerBase
    {
        private readonly IRepository<Technician> _jobRepository;
        private readonly IMapper _mapper;
        public TechnicianController(IRepository<Technician> repo, IMapper mapper)
        {
            _jobRepository = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetTechnicians()
        {
            var model = await _jobRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<TechnicianDto>>(model));
        }


    }

}