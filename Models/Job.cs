namespace fixit.Models
{
    public class Job
    {
        public int JobId { get; set; }

        public string JobName { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public string Location { get; set; }

        public int TechnicianId { get; set; }

        public string AccepteStatus { get; set; }

        public string DoneStatus { get; set; }

        public User User { get; set; }

        public Technician Technician { get; set; }






    }
}