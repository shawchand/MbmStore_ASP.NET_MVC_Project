using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbmStore.Models
{
	public class Customer 
	{
		[Column(TypeName = "datetime2")]
		public DateTime Birthdate { get; set; }


		//automatic properties
		public int CustomerId { get; set; }
		public string Firstname { get; set; }

		public string Lastname { get; set; }
		
		public string Address { get; set; }
		
		public string Zip { get; set; }
		
		public string City { get; set; }

		public string Email { get; set; }



		public int Age
		{
		// code inside the get block of the Age property 
		get
		{
			DateTime now = DateTime.Now;
		int age;
		age = now.Year -  Birthdate.Year;
		// calculate to see if the customer hasn’t had birthday yet
		 if (now.Month < Birthdate.Month || (now.Month == Birthdate.Month && now.Day < Birthdate.Day))
			{
			 age--;
			}
			return age;
		}
		}

		public virtual ICollection<Invoice> Invoices { get; set; }
		public virtual ICollection<Phone> PhoneNumbers { get; set; }


		public Customer()
		{

		}

		//constructors
		public Customer(int customerid, string firstname, string lastname, string address, string zip, string city, DateTime birthdate)
		{
			this.CustomerId = customerid;
			this.Firstname = firstname;
			this.Lastname = lastname;
			this.Address = address;
			this.Zip = zip;
			this.City = city;
			this.Birthdate = birthdate;
			
		}

		//Methods or Functions
		public void addPhone(Phone phone)
		{
			PhoneNumbers.Add(phone);
		}

		public void AddInvoice(Invoice invoice)
		{
			Invoices.Add(invoice);
		}
	}

}