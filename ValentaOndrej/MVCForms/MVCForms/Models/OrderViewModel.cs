using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCForms.Models.Enums;

namespace MVCForms.Models
{
    public class OrderViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserTypes UserType { get; set; }
        public int MealId { get; set; }
        public DateTime Date { get; set; }
    }
}