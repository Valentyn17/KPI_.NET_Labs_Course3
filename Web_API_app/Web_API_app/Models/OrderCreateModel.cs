using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_API_app.Models
{
    public class OrderCreateModel
    {
       

        [Required(ErrorMessage = "Field can't be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Range(0, 1000)]
        public int Count { get; set; }
       
        public int GoodId { get; set; }

 
    }
}