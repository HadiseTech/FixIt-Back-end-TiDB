using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using fixit.Data;
using fixit.DTO;
using fixit.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers{

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
            List<Job> jobs = new List<Job>();
            var result = new List<JobDto>();
            foreach( var s in model){
                JobDto dto = new JobDto{
                    JobId = s.JobId,
                    JobName = s.JobName,
                    Description = s.Description,
                };
                result.Add(dto);
            };
            // return Ok(_mapper.Map<IEnumerable<JobDto>>(model));
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            
            var model = await _jobRepository.GetDataById(id);
            return Ok(_mapper.Map<JobDto>(model));
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(JobDto JobDto)
        {
            
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
    }

}