using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fixit.Models
{
    public class TechnicianDto
    {



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TechnicianId { get; set; }

        public int UserId { get; set; }

        public string Experiance { get; set; }

        public int CompletedWork { get; set; }

        public string Department { get; set; }

        public User User { get; set; }












    }
}