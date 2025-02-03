using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageent
{
    public class LibraryTest
    {
        public static void RunTests(IServiceProvider serviceProvider)
        {
            var bookRepo = serviceProvider.GetService<IBookRepository>();
            var userRepo = serviceProvider.GetService<IUserRepository>();
            var loanRepo = serviceProvider.GetService<ILoanRepository>();
        }
    }
}
