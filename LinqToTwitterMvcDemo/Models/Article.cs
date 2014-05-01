using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LinqToTwitterMvcDemo.Models
{

    public partial class article
    {
        
        public double AverageRating { get; set; }
        public string FirstComment { get; set; }
        public double NumComments { get; set; }
    }
}