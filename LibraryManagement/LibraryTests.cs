using Library.Domain.Entity;
using Library.Domain.IRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public static class LibraryTests
    {
        public static void RunTests(IServiceProvider serviceProvider)
        {
            var bookRepo = serviceProvider.GetService<IBookRepository>();
            var userRepo = serviceProvider.GetService<IUserRepository>();
            var loanRepo = serviceProvider.GetService<ILoanRepository>();

            bookRepo.AddBook(new Book { Id = 1, Title = "C# Basics", Author = "John Doe", PublishedYear = 2020, IsAvailable = true });
            bookRepo.AddBook(new Book { Id = 2, Title = "Advanced C#", Author = "Jane Smith", PublishedYear = 2021, IsAvailable = true });


            // Add and Test Book
            Console.WriteLine("Books:");
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var book in bookRepo.GetAllBooks())
                Console.WriteLine($"{book.Id}: {book.Title} by {book.Author}");
            Console.ResetColor();

            // Add and Test Users
            userRepo.AddUser(new User { Id = 1, Name = "Soheil Imani", Email = "soheil@example.com" });
            userRepo.AddUser(new User { Id = 2, Name = "Sara Ahmadi", Email = "sara@example.com" });

            Console.WriteLine("Users:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var user in userRepo.GetAllUsers())
                Console.WriteLine($"{user.Id}: {user.Name} ({user.Email})");
            Console.ResetColor();

            // Loan and Test
            Console.WriteLine("\nAttempting to loan books...");
            try
            {
                loanRepo.LoanBook(1, 1);
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("Book 1 loaned successfully to User 1!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error while loaning Book 1: {ex.Message}");
                Console.ResetColor();
            }

            try
            {
                loanRepo.LoanBook(2, 2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book 2 loaned successfully to User 2!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error while loaning Book 2: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nActive Loans:");
            foreach (var loan in loanRepo.GetActiveLoans())
                Console.WriteLine($"Book {loan.BookId} loaned by User {loan.UserId} on {loan.LoanDate}");

            // Return and Test
            Console.WriteLine("\nAttempting to return books...");
            try
            {
                loanRepo.ReturnBook(1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book 1 returned successfully!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error while returning Book 1: {ex.Message}");
                Console.ResetColor();
            }

            try
            {
                loanRepo.ReturnBook(2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book 2 returned successfully!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error while returning Book 2: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
