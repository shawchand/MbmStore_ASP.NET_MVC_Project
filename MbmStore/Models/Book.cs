using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbmStore.Models
{
	//derived class from base Product class
	[Table("Book")]
	public class Book : Product
	{

		public string Author { get; set; }
		public string Publisher { get; set; }
		public short Published { get; set; }
		public string ISBN { get; set; }

	
		//constructors
		public Book()
		{

		}
		public Book(string author, string title, decimal price, string publisher, short published, string isbn, string imageurl) : base(title, price)
		{
			this.Author = author;
			this.Publisher = publisher;
			this.Published = published;
			this.ISBN = isbn;
			this.ImageUrl = imageurl;
		}
	}

}