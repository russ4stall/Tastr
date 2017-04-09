using Tastr.Data;

namespace Tastr.Api
{
    public class ItemDto
    {
        public ItemDto(Item item)
        {
            this.Id = item.Id;
            this.Name = item.Name;
            this.Description = item.Description;            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
    }
}
