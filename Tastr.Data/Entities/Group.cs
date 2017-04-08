using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tastr.Data
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Session> Sessions { get; set; }
        public List<GroupUser> Users { get; set; }
    }
}
