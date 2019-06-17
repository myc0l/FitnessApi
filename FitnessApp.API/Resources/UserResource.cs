using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.API.Resources
{
    public class UserResource
    {
        
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
}