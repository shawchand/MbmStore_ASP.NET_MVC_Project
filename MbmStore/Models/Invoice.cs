using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MbmStore.Models
{
	public class Invoice
	{
		//fields
		private decimal totalPrice;
		private List<OrderItem> orderItems = new List<OrderItem>();

		//automatic properties
		public int InvoiceId { get; set; }

		//[Column(TypeName = "datetime2")]
		public DateTime OrderDate { get; set; }

		public int CustomerId { get; set; }

		public Customer Customer { get; set; }

		//read-only properties
		public decimal TotalPrice
		{
			get { return totalPrice; }
		}

		public List<OrderItem> OrderItems
		{
			set { orderItems = value ; }

			get { return orderItems; }
		}

		//constructor
		public Invoice()
		{

		}

		public Invoice(int invoiceid, DateTime orderDate, Customer customer)
		{
			this.InvoiceId = invoiceid;
			this.OrderDate = orderDate;
			this.Customer = customer;
		}


		public Invoice( DateTime orderDate, Customer customer)
		{
			this.OrderDate = orderDate;
			this.Customer = customer;
		}

		//method
		public void AddOrderItem(Product product, int quantity)
		{
			orderItems.Add(new OrderItem(product, quantity));
		}


		public decimal GetTotalPrice()
		{
			decimal total = 0m;
			
			foreach (OrderItem tp1 in OrderItems)
			{
				total += tp1.Quantity * tp1.Product.Price;
			
			}
			return total;

		}
	}
}