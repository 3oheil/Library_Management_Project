using Library.Data.Repository;
using Library.Domain.IRepository;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IBookRepository, BookRepository>()
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<ILoanRepository, LoanRepository>()
                .BuildServiceProvider();

            LibraryTests.RunTests(serviceProvider);
        }
    }
}
