using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace midterm2.Models
{
    public class Cart
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public string show_id { get; set; }

        [Display(Name = "Movie Id")]
        public int? movie_id { get; set; }

        [Display(Name = "Show date")]
        public DateTime show_date { get; set; }


        [Display(Name = "Show time")]
        public string show_time { get; set; }

        [Display(Name = "show price")]
        public Double show_price { get; set; }


        [Display(Name = "show quantity")]
        public int show_quantity { get; set; }

        [Display(Name = "Total")]
        public Double Total
        {
            get { return show_quantity * show_price; }
        }

        public Cart(string id)
        {
            show_id = id;
            Showtime b = db.Showtimes.Single(n => n.show_id == show_id);
            movie_id = b.movie_id;
            show_date = DateTime.Parse(b.show_date.ToString());
            show_price = double.Parse(b.show_price.ToString());
            show_quantity = 1;
        }

    }
}