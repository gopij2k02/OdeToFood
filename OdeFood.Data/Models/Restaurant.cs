﻿using System.ComponentModel.DataAnnotations;

namespace OdeFood.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Type of food")]// Used to display this name in the view model
        public CuisineType Cuisine { get; set; }
    }
}
