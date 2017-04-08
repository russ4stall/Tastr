using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tastr.Data
{
    public class Session
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public List<SessionItem> SessionItems { get; set; }
    }
}
