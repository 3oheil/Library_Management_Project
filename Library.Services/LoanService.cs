using Library.Domain.Entity;
using Library.Domain.IRepository;

namespace Library.Services
{
    public class LoanService
    {

        private readonly IBookRepository _bookRepo;
        private readonly ILoanRepository _loanRepo;

        public LoanService(IBookRepository bookRepo, ILoanRepository loanRepo)
        {
            _bookRepo = bookRepo;
            _loanRepo = loanRepo;
        }

        public void LoanBook(int bookId, int userId)
        {
            var book = _bookRepo.GetBookById(bookId);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {bookId} not found.");
            }
            if (!book.IsAvailable)
            {
                throw new InvalidOperationException("Book is already loaned out.");
            }

            _loanRepo.LoanBook(bookId, userId);
        }

        public void ReturnBook(int bookId)
        {
            var loan = _loanRepo.GetActiveLoans().FirstOrDefault(l => l.BookId == bookId);
            if (loan == null)
            {
                throw new InvalidOperationException("This book is not currently loaned out.");
            }

            _loanRepo.ReturnBook(bookId);
        }

        public IEnumerable<Loan> GetActiveLoans() => _loanRepo.GetActiveLoans();
    }


}
