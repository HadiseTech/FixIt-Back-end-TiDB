using System.Collections.Generic;
using System.Threading.Tasks;

using fixit.Models;
using Microsoft.EntityFrameworkCore;

namespace fixit.Data
{
    public class TechnicianRepository : IRepository<Technician>
    {
        private readonly DataContext _context;
        public TechnicianRepository(DataContext context)
        {
            _context = context;
        }

        async Task<bool> IRepository<Technician>.DeleteData(Technician service)
        {
            _context.Technician.Remove(service);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<List<Technician>> IRepository<Technician>.GetData()
        {
            var data = await _context.Technician
            .Include(e => e.User)
             .ToListAsync();
            return data;
        }

        async Task<Technician> IRepository<Technician>.GetDataById(int id)
        {
            return await _context.Technician.FirstOrDefaultAsync(x => x.TechnicianId == id);
        }

        async Task<Technician> IRepository<Technician>.InsertData(Technician service)
        {
            _context.Technician.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        async Task<Technician> IRepository<Technician>.UpdateData(Technician service)
        {
            _context.Update(service).Property(x => x.TechnicianId).IsModified = false;
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<List<Technician>> GetDataByConstraint(int pageNumber, int pageSize,string orderBy,string search)
        {
                  var data = await _context.Technician
  .Include(e => e.User)
   .ToListAsync();
  return data;
        }
         public async Task<int> GetTotalPage(int pageSize,string search){
             return 0;
         }
    }

}
