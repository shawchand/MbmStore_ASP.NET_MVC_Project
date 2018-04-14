using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbmStore.Models
{

	public class OrderItem
	{
		public int OrderItemId { get; set; }
		public int ProductId { get; set; }
		public int InvoiceId { get; set; }
		public int Quantity { get; set; }
		public decimal TotalPrice { get { return Quantity * Product.Price; } }

		// navigation property 
		public virtual Product Product { get; set; }

		public OrderItem() { }

		public OrderItem(Product product, int quantity)
		{
			Product = product;
			Quantity = quantity;
		}
		public OrderItem(int orderItemID, Product product, int quantity)
		{
			OrderItemId = orderItemID; Product = product; Quantity = quantity;
		}
	}
}