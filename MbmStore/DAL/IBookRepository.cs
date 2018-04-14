using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbmStore.Models;

namespace MbmStore.DAL
{
	public interface IBookRepository
	{
		IEnumerable<Book> GetBookList();
		Book GetBookById(int id);
		void SaveBook(Book book);
		Book DeleteBook(int bookId);
	}
}
