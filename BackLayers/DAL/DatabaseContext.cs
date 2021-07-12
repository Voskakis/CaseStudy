using BackLayers.Models;
using System.Data.Entity;

namespace BackLayers.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Click> Clicks { get; set; }
        public DbSet<MyUser> Users { get; set; }
        public DatabaseContext() : base("CASE")
        { }
    }
}