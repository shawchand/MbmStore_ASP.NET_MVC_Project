using MbmStore.Infrastructure;
using MbmStore.Models;
using MbmStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MbmStore.DAL;
using System.Data.Entity;

namespace MbmStore.Controllers
{
    public class CartController : Controller
    {
		private MbmStoreContext db = new MbmStoreContext();
		// constructor
		// instantiale a new db object 
		public CartController()
		{
			db = new MbmStoreContext();
		}
			public ViewResult Index(Cart cart, string returnUrl)
		{
			return View(new CartIndexViewModel
			{
				Cart = cart,
				ReturnUrl = returnUrl
			});
		}

		public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
		{
			Product product = db.Products.FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				cart.AddItem(product, 1);
			}
			return RedirectToAction("Index", new { controller = returnUrl.Substring(1) });
		}

		public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
		{
			Product product = db.Products.FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				cart.RemoveItem(product);
			}
			return RedirectToAction("Index", new { controller = "Cart" });
		}

		private Cart GetCart()
		{
			Cart cart = (Cart)Session["Cart"];
			if (cart == null) { cart = new Cart(); Session["Cart"] = cart; }
			return cart;
		}

		public PartialViewResult Summary(Cart cart)
		{
			return PartialView(cart);
		}

		public ViewResult Checkout()
		{
			return View(new ShippingDetails());
		}

		[HttpPost]
		public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
		{
			if (cart.Lines.Count() == 0)
			{
				ModelState.AddModelError("", "Sorry, your cart is empty!");
			}

			if (ModelState.IsValid)
			{
				Customer customer = new Customer
				{
					Firstname = shippingDetails.Firstname,
					Lastname = shippingDetails.Lastname,
					Address = shippingDetails.Address,
					Zip = shippingDetails.Zip,
					Email = shippingDetails.Email
				};

				if (db.Customers.Any(c => c.Firstname == customer.Firstname && c.Lastname == customer.Lastname && c.Email == customer.Email))
				{
					customer = db.Customers.Where(c => c.Firstname == customer.Firstname && 
					c.Lastname == customer.Lastname && 
					c.Email == customer.Email).First();
					customer.Address = shippingDetails.Address;
					customer.Zip = shippingDetails.Zip;
					// ensure update instead of insert 
					db.Entry(customer).State = EntityState.Modified;
				}
				// order processing logic
				Invoice invoice = new Invoice(DateTime.Now, customer);

				foreach (CartLine cartline in cart.Lines)
				{
					OrderItem orderItem = new OrderItem(cartline.Product, cartline.Quantity);
					orderItem.ProductId = cartline.Product.ProductId;
					orderItem.Product = null;
					invoice.OrderItems.Add(orderItem);
				}
				db.Invoices.Add(invoice);
				db.SaveChanges();
				cart.Clear();
				return View("Completed");
			}

			else
			{
				return View(shippingDetails);
			}
		}
	}
}