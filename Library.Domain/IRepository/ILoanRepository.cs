using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.IRepository
{
    public interface ILoanRepository
    {
        void LoanBook(int bookId, int userId);
        void ReturnBook(int bookId);

        IEnumerable<Loan> GetActiveLoans();
    }
}
