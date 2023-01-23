using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Infinite.MVC.DemoProject.Models
{
    public class Pets
    {
        public int Id { get; set; }
        [Required]
        public string PetName { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int BreedsId { get; set; }

        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }

        public Breeds Breeds { get; set; }

    }
}