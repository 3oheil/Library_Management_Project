using Library.Domain.Entity;
using Library.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repository
{
    public class LoanRepository : ILoanRepository
    {

        private readonly List<Loan> loans = new();
        private readonly IBookRepository _bookRepository;

        public LoanRepository(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Loan> GetActiveLoans()
        {
            return loans.Where(l => l.ReturnDate == null);
        }

        public void LoanBook(int bookId, int userId)
        {
            var book = _bookRepository.GetBookById(bookId);
            if (book != null && book.IsAvailable)
            {
                book.IsAvailable = false;
                loans.Add(new Loan
                {
                    BookId = bookId,
                    UserId = userId,
                    LoanDate = DateTime.Now,
                    ReturnDate = null
                });
            }
        }

        public void ReturnBook(int bookId)
        {
            var loan = loans.FirstOrDefault(l => l.BookId == bookId && l.ReturnDate == null);
            if (loan != null)
            {
                loan.ReturnDate = DateTime.Now;
                var book = _bookRepository.GetBookById(bookId);
                if (book != null)
                {
                    book.IsAvailable = true;
                }
            }
        }
    }
}
