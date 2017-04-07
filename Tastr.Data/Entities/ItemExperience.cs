namespace Tastr.Data
{
    public class ItemExperience
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Item Item { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }
    }
}
