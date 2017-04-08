using System.ComponentModel.DataAnnotations;

namespace Tastr.Data
{
    public class SessionItem
    {
        public int Id { get; set; }
        [Required]
        public Item Item { get; set; }
        [Required]
        public Session Session { get; set; }
    }
}
