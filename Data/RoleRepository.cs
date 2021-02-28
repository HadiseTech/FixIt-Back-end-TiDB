using System.Threading.Tasks;

using fixit.Models;
using Microsoft.EntityFrameworkCore;

namespace fixit.Data
{
    public class JobRepository : IRepository<Role>
    {
        private readonly DataContext _context;
        public JobRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteData(Role role)
        {
            _context.Role.Remove(role);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<System.Collections.Generic.List<Role>> GetData()
        {
            var data = await _context.Role
             .Include(e => e.User)
             .Include(e => e.Technician)
             .ToListAsync();
            return data;
        }

        public async Task<Role> GetDataById(int id)
        {
            return await _context.Role.FirstOrDefaultAsync(x => x.JobId == id);

        }

        public async Task<Role> InsertData(Role role)
        {
            _context.Role.Add(role);
            await _context.SaveChangesAsync();
            return role;

        }
        public async Task<Role> UpdateData(Role role)
        {
            _context.Update(role).Property(x => x.JobId).IsModified = false;
            await _context.SaveChangesAsync();
            return role;
        }
    }

}
