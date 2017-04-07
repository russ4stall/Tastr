using System;
using System.Collections.Generic;

namespace Tastr.Data
{
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public List<Item> Items { get; set; }
        public DateTime DateTime { get; set; }
    }
}
