using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models
{
	public static class Repository
	{
		//List of products and invoices
		public static List<Product> Products = new List<Product>();
		public static List<Invoice> Invoices = new List<Invoice>();

		//contructor
		static Repository()
		{
			//create objects
			Book book = new Book("Ram Mohan Roy", "A Gift of Monotheists", 160.50m, "Its Book", 1998, "00608994488", "monotheists.gif");
			book.ProductId = 1;
			book.Category = "Book";
			Products.Add(book);
			Book book1 = new Book("V.S.Naipaul", "A House for Mr.Biswas", 155.50m, "Missing", 2001, "005588776655", "biswas.jpg");
			book1.ProductId = 2;
			book1.Category = "Book";
			Products.Add(book1);

			Movie jungleBook = new Movie("Jungle Book", 160.50m, "junglebook.jpg", "John Favreau");
			jungleBook.ProductId = 3;
			jungleBook.Category = "Movie";
			Products.Add(jungleBook);
			Movie gameofThrones = new Movie("Game of Thrones", 188.88m, "gmtr.jpg", "Brian Kirk");
			gameofThrones.ProductId = 4;
			gameofThrones.Category = "Movie";
			Products.Add(gameofThrones);

			MusicCD CD = new MusicCD("Arijit Singh", "Tum Hi ho", 122.50m, 2016, "tumhiho.jpg");
			CD.AddTrack(new Track("Taxman", "McCartney", new TimeSpan(0, 2, 28)));
			CD.AddTrack(new Track("Come Together", "Harrison", new TimeSpan(0, 2, 06)));
			CD.AddTrack(new Track("Something", "Lennon", new TimeSpan(0, 3, 28)));
			CD.AddTrack(new Track("Oh! Darling", "Harrison", new TimeSpan(0, 3, 00)));
			CD.ProductId = 5;
			CD.Category = "MusicCD";
			Products.Add(CD);

			MusicCD CD3 = new MusicCD("Honey Singh", "Swaag", 170.50m, 2015, "swaag.jpg");
			CD3.AddTrack(new Track("I am Only Sleeping", "Lennon", new TimeSpan(0, 2, 25)));
			CD3.AddTrack(new Track("Yellow Submarine", "Harrison", new TimeSpan(0, 1, 18)));
			CD3.AddTrack(new Track("She said She said", "McCartney", new TimeSpan(0, 2, 29)));
			CD3.AddTrack(new Track("For No One", "Harrison", new TimeSpan(0, 3, 01)));
			CD3.AddTrack(new Track("I Want To Tell You", "McCartney", new TimeSpan(0, 2, 14)));
			CD3.ProductId = 5;
			CD3.Category = "MusicCD";
			Products.Add(CD3);

			Customer c1 = new Customer(1, "John", "Shaun", "London", "AB01", "Brent", new DateTime(2013, 1, 23));
			c1.addPhone("99887766");
			c1.addPhone("88776655");

			Customer c2 = new Customer(2, "Tom", "Shaw", "Denmark", "CC02", "Aarhus", new DateTime(2000, 1, 20));
			c2.addPhone("76787980");
			c2.addPhone("34354647");

			Invoice I1 = new Invoice(1, new DateTime(2017, 1, 23), c1);
			

			Invoice I2 = new Invoice(2, new DateTime(2017, 5, 30), c2);
			

			Product P1 = new Product("Arijit Singh", 122.50m);
			Product P2 = new Product("Jungle Book", 160.50m);
			Product P3 = new Product("Honey Singh", 170.50m);
			Product P4 = new Product("V.S.Naipaul", 155.50m);

			I1.AddOrderItem(P1,1);
			I1.AddOrderItem(P2, 2);

			I2.AddOrderItem(P3, 2);
			I2.AddOrderItem(P4, 1);

			Invoices.Add(I1);
			Invoices.Add(I2);
		}
	}
}