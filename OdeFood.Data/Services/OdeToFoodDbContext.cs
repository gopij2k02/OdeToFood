using OdeFood.Data.Models;
using System.Data.Entity;

namespace OdeFood.Data.Services
{
    public class OdeToFoodDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
