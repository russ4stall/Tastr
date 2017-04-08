using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tastr.Data
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }    
        public List<ItemExperience> ItemExperiences { get; set; }
        public List<Session> Sessions { get; set; }
        public List<GroupUser> Groups { get; set; }
    }
}
