
using fixit.Models;
using Microsoft.EntityFrameworkCore;
namespace fixit.Data

{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<User> User { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Technician> Technician { get; set; }


     

    
    


    
    
    

    
            
    }
}

