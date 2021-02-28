using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using fixit.Data;

using fixit.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Controllers
{

    [Route("api/jobs")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IRepository<Job> _jobRepository;
        private readonly IMapper _mapper;
        public JobController(IRepository<Job> repo, IMapper mapper)
        {
            _jobRepository = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var model = await _jobRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<JobDto>>(model));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            Console.WriteLine("Returning job of id" + id);
            var model = await _jobRepository.GetDataById(id);
            return Ok(_mapper.Map<JobDto>(model));
        }
        [HttpPost]
        public async Task<IActionResult> CreateJob(JobDto JobDto)
        {
            Console.WriteLine("Creating Job");
            var Job = _mapper.Map<Job>(JobDto);
            await _jobRepository.UpdateData(Job);
            return Ok(JobDto);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteJobs(int id)
        {
            var model = await _jobRepository.GetDataById(id);
            var Job = _mapper.Map<Job>(model);
            await _jobRepository.DeleteData(Job);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, JobDto job)
        {
            Console.WriteLine(job.AccepteStatus);
            var Job = _mapper.Map<Job>(job);
            await _jobRepository.UpdateData(Job);
            return Ok(job);
        }
    }

}