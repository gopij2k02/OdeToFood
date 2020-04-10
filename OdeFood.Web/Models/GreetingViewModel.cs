using OdeFood.Data.Models;
using System.Collections.Generic;

namespace OdeFood.Web.Models
{
    public class GreetingViewModel
    {
        public string Message { get; set; }
        public IEnumerable<Restaurant> restaurants { get; set; }
    }
}