using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.IRepository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        User GetUser(int id);


        IEnumerable<User> GetAllUsers();
        IEnumerable<User> SearchUsersByName(string name);
    }
}
