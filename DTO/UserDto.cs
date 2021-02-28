using fixit.Models;

namespace fixit.DTO{
    public class UserDto{
         public int UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Picture { get; set; }

        public string Sex { get; set; }

        public System.DateTime Dob { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

    }

    
}