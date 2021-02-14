using System.Threading.Tasks;
using fixit.DTO;
using fixit.Models;
using Microsoft.EntityFrameworkCore;

namespace fixit.Data
{
    public class JobRepository : IRepository<Job>
    {
        private readonly DataContext _context;
        public JobRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteData(Job job)
        {
            _context.Job.Remove(job);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<System.Collections.Generic.List<Job>> GetData()
        {
                var data = await  _context.Job.ToListAsync();
                return data;
        }

        public async Task<Job> GetDataById(int id)
        {
            return await _context.Job.FirstOrDefaultAsync(x => x.JobId == id);

        }

        public async  Task<Job> UpdateData(Job job)
        {
             _context.Job.Add(job);
            await _context.SaveChangesAsync();
            return job;

        }
       public async Task<Job> PutJob(Job job){
           var newJob = _context.Job.FirstOrDefaultAsync(x => x.JobId == job.JobId);
         _context.Entry(job).State = EntityState.Modified;
         await _context.SaveChangesAsync();
         return job;
       }

        // public async Task<Job> PutJob(JobDto job)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
    
}
