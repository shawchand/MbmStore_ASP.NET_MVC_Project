using MbmStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MbmStore.Models;
using MbmStore.DAL;

namespace MbmStore.Controllers
{
	public class NavController : Controller
	{
		private MbmStoreContext db = new MbmStoreContext();
		// constructor
		// instantiale a new db object 
		public NavController()
		{
			db = new MbmStoreContext();
		}

		public PartialViewResult Menu(string category = null)
		{
			ViewBag.SelectedCategory = category;
			IEnumerable<string> categories = db.Products
				.Select(x => x.Category)
				.Distinct()
				.OrderBy(x => x);
			return PartialView(categories);
		}
	}
}