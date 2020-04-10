using OdeFood.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OdeFood.Data.Services
{
    public class SqlDbRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;
        public SqlDbRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            //var res = Get(id);
            var res = db.Restaurants.Find(id);// This find is different from LINQ and this is most efficient way to search.
            db.Restaurants.Remove(res);
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            //return db.Restaurants;
            //return db.Restaurants.ToList();
            return from r in db.Restaurants
                   orderby r.Name
                   select r;
        }

        public void Update(Restaurant restaurant)
        {
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
