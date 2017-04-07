using System.Collections.Generic;

namespace Tastr.Data
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
