using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using fixit.Models;


namespace fixit.Data
{
    public class ServiceRepository : IRepository<Service>
    {
        private readonly DataContext _context;
        
        public ServiceRepository(DataContext context)
        {
            _context = context;
        }
        // Delete Service objects
        public async Task<bool> DeleteData(Service service)
        {
            Console.WriteLine("Delete method invoked");
            _context.Service.Remove(service);
            await _context.SaveChangesAsync();
            return true;
        }


        // Get all service objects
        public async Task<List<Service>> GetData()
        {
            //    Getting database data here
            var model = await _context.Service.ToListAsync();
            return model;

        }
        // Get Service by  id
        public async Task<Service> GetDataById(int id)
        {
            return await _context.Service.FirstOrDefaultAsync(x => x.ServiceId == id);
        }


        // 
        // Get data by constraint
         public async Task<List<Service>> GetDataByConstraint(int pageNumber, int pageSize,string orderBy,string search)
            {
                // search="hello";
                
                

        switch (orderBy)
                     {
                        case "Category":
                                if(search=="0"){
                                   return await _context.Service
                                    .OrderBy(s=>s.Category)
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
                     
                                }else{
                                     return await _context.Service
                                    .Where(b => b.ServiceName ==  search)
                                    .OrderBy(s=>s.Category)
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
                                 }
                            // model=model.orderBy(s=>s.Category).ToListAsync();
                                break;
                    case "ServiceName":
                            if(search=="0"){
                                return await _context.Service
                                    .OrderBy(s=>s.ServiceName)
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
                            }else{
                                return await _context.Service
                                        .Where(b => b.ServiceName ==  search)
                                        .OrderBy(s=>s.ServiceName)
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
                            }
                            // model=model.orderBy(s=>s.ServiceName).ToListAsync();
                            break;
                    case "InitialPrice":
                            if(search=="0"){
                                return await _context.Service
                                    .OrderBy(s=>s.InitialPrice)
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
                            }else{
                                return await _context.Service
                                    .Where(b => b.ServiceName ==  search)
                                    .OrderBy(s=>s.InitialPrice)
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
                            }
                            // model=model.orderBy(s=>s.InitialPrice).ToListAsync();
                            break;
                         default:
                            if(search=="0"){
                                return await _context.Service
                                    .OrderBy(s=>s.ServiceName)
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
                            }else{
                                return await _context.Service
                                    .Where(b => b.ServiceName ==  search)
                                    .OrderBy(s=>s.ServiceName)
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
                            }
                            // model=model.orderBy(s=>s.ServiceName).ToListAsync();
                             break;

                     }

                    
        }
        public async Task<int> GetTotalPage(int pageSize,string search){
            if(search!="0"){
                // 
                   var count = await _context.Service.Where(b => b.ServiceName ==  search).CountAsync();
                   var totalPages = (int)Math.Ceiling(count / (float)pageSize);
                    return totalPages;

            }else{
                // 
                var count = await _context.Service.CountAsync();
                var totalPages = (int)Math.Ceiling(count / (float)pageSize);
                return totalPages;
            }
             
             

             
        }
        

        public Task<Service> PutJob(Service job)
        {
            throw new NotImplementedException();
        }

        // Update and crete new service objects
        public async Task<Service> InsertData(Service service)
        {

            Console.WriteLine("Create data  method invoked");
            _context.Service.Add(service);

            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<Service> UpdateData(Service service)
        {




            Console.WriteLine("Update method  invoked");



            _context.Update(service).Property(x => x.ServiceId).IsModified = false;
            _context.SaveChanges();












            // _context.Service.Add(service);
            // 
            // _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Fixit_DB.Service ON;");
            // await _context.SaveChangesAsync();
            // _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Fixit_DB.Service OFF");
            return service;
        }
    }
}