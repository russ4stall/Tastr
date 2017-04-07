using Microsoft.EntityFrameworkCore;

namespace Tastr.Data
{
    public class TastrContext : DbContext
    {
        public TastrContext(DbContextOptions<TastrContext> options) : base(options)
        { }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemExperience> ItemExperiences { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}