using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.IRepository
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        Book GetBookById(int id);


        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> SearchBooksByTitle(string title);
        IEnumerable<Book> SearchBooksByAuther(string auther);
    }
}
