using MbmStore.Infrastructure;
using MbmStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MbmStore.Models;
using MbmStore.DAL;

namespace MbmStore.Controllers
{
    public class CatalogueController : Controller
    {
		private MbmStoreContext db = new MbmStoreContext();
		public int PageSize = 4;
		// GET: Catalogue
		public ActionResult Index(string category, int page = 1)
		{
			db = new MbmStoreContext();
			ProductsListViewModel model = new ProductsListViewModel
			{
				Products = db.Products
				.Where(p => category == null || p.Category == category)
				.OrderBy(p => p.ProductId)
				.Skip((page - 1) * PageSize)
				.Take(PageSize).ToList(),

				PagingInfo = new PagingInfo
				{
					CurrentPage = page,
					ItemsPerPage = PageSize,
					TotalItems = category == null ? db.Products.Count() : db.Products.Where(e => e.Category == category).Count()
				},
				CurrentCategory = category
			};
			return View(model);
		}

		// GET: Catalogue
		//public ActionResult Index()
  //      {

		//	IList<Book> books = new List<Book>();
		//	books = Repository.Products.OfType<Book>().ToList();
		//	ViewBag.Books = books;

		//	IList<Movie> movies = new List<Movie>();
		//	movies = Repository.Products.OfType<Movie>().ToList();
		//	ViewBag.Movies = movies;

		//	IList<MusicCD> music = new List<MusicCD>();
		//	music = Repository.Products.OfType<MusicCD>().ToList();
		//	ViewBag.Music = music;

		//	ViewBag.Products = Repository.Products;

		//	return View(Repository.Products);
  //      }
    }
}