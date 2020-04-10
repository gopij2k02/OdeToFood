using OdeFood.Data.Models;
using OdeFood.Data.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace OdeFood.Web.Api
{
    public class RestaurantsController : ApiController
    {
        IRestaurantData db;
        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }

        public IEnumerable<Restaurant> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
