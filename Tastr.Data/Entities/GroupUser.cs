using System.ComponentModel.DataAnnotations;

namespace Tastr.Data
{
    public class GroupUser
    {
        public int Id { get; set; }
        [Required]
        public Group Group { get; set; }
        [Required]
        public User User { get; set; }
    }
}
