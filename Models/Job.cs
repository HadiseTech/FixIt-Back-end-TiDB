namespace fixit.Models
{
    public class Job {
        public int JobId  { get; set; }
        
        public string JobName    { get; set; }

        public string Description { get; set; }
        
        public int AddedBy { get; set; }
        
        public string Location { get; set; }
        
        public int AssignedTechnician { get; set; }
        
        public string AccepteStatus { get; set; }
        
        public string DoneStatus { get; set; }
        
        
        
        
    }
}