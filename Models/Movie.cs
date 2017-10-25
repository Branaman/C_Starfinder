using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace C_Starfinder.Models
{
    public class Movie : BaseEntity
    {
        [Required]
        public string title { get; set; }
        [Required]
        public float rating {get;set;}
        [Required]
        public DateTime released {get;set;}
        public int idmovies {get;set;}
    }
}