using System.Collections.Generic;

namespace Tastr.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public List<ItemExperience> ItemExperiences { get; set; }
        public List<Session> Sessions { get; set; }
        
    }
}
