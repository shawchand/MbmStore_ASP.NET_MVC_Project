using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MbmStore.Models;
using MbmStore.DAL;



namespace MbmStore.Controllers
{
    public class InvoiceController : Controller
    {
		private MbmStoreContext db = new MbmStoreContext();
		// constructor
		// instantiale a new db object 
		public InvoiceController()
		{
			db = new MbmStoreContext();
		}
		// GET: Invoice
		public ActionResult Index()
		{
			ViewBag.Invoices = db.Invoices;
			return View();
		}
	}
}