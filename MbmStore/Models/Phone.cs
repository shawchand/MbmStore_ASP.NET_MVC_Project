using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models
{
	public class Phone
	{
		//automatic properties
		public int PhoneId { get; set; }
		public string PhoneNumber { get; set; }
		public int CustomerID { get; set; }
		public Customer Customer { get; set; }
		public string PhoneType { get; set; }
	}
}