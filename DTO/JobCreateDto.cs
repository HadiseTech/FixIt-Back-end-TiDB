using fixit.Models;

namespace fixit.DTO{
    public class JobCreateDto{
       public string JobName { get; set; }

        public string Description { get; set; }

        public int ? UserId { get; set; }

        public string Location { get; set; }

        public int ? TechnicianId { get; set; }

        public string AccepteStatus { get; set; }

        public string DoneStatus { get; set; }

    }

    
}