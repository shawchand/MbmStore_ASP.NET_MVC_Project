using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbmStore.Models
{
	[Table("Movie")]
	public class Movie : Product
    {
        // fields
		public string director;

        // properties
		public string Director{ get; set; }

		// constructor
		public Movie()
		{

		}

		public Movie(string title, decimal price, string imageUrl, string director) : base(title, price)
        {
            this.ImageUrl = imageUrl;
			this.Director = director;
        }
    }
}