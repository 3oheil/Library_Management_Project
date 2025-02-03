using Library.Domain.Entity;
using Library.Domain.IRepository;

namespace Library.Data
{
    public class BookRepository : IBookRepository
    {
        private List<Book> books = new();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void DeleteBook(int id)
        {

            var isexist = books.FirstOrDefault(b => b.Id == id);
            if (isexist == null)
            {
                throw new NullReferenceException("No book was found with this id");
            }

            books.Remove(isexist);
        }

        public IEnumerable<Book> GetAllBooks() => books;


        public Book GetBookById(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> SearchBooksByAuther(string auther)
        {
            return books.Where(b => b.Author == auther);

        }

        public IEnumerable<Book> SearchBooksByTitle(string title)
        {
            return books.Where(b => b.Title == title);
        }

        public void UpdateBook(Book book)
        {
            var isExist = GetBookById(book.Id);
            if (isExist == null)
            {
                throw new NullReferenceException("No book was found with this id");
            }
            isExist.Author = book.Author;
            isExist.Title = book.Title;
            isExist.PublishedYear = book.PublishedYear;
        }
    }
}
