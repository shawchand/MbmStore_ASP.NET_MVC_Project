using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbmStore.Models
{
	//base class
	public class Product
	{
		//automatic properties
		public int ProductId { get; set; }
		public string Title { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public string Category { get; set; }

		[Column(TypeName = "datetime2")]
		public DateTime? CreatedDate { get; set; }

		//constructors
		public Product()
		{

		}

		public Product(string title, decimal price)
		{
			this.Title = title;
			this.Price = price;
		}
	}
}