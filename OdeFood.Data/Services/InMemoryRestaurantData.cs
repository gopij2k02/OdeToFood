using OdeFood.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant{Id= 1, Name = "Olive Gardern",Cuisine = CuisineType.Italian},
                new Restaurant{Id = 2,Name = "Cash And Carry",Cuisine = CuisineType.Indian},
                new Restaurant{Id = 3,Name = "Panda Express",Cuisine = CuisineType.Chines},
            };
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(x => x.Id) + 1;
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if (existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public void Delete(int id)
        {
            var res = Get(id);
            if (res != null)
                restaurants.Remove(res);
        }
    }
}
