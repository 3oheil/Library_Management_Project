using Library.Domain.Entity;
using Library.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new();

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void DeleteUser(int id)
        {
            var isexist = users.FirstOrDefault(b => b.Id == id);
            if (isexist == null)
            {
                throw new NullReferenceException("No user was found with this id");
            }

            users.Remove(isexist);
        }

        public IEnumerable<User> GetAllUsers() => users;
        

        public User GetUser(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> SearchUsersByName(string name)
        {
            return users.Where(u=>u.Name == name);
        }

        public void UpdateUser(User user)
        {
            var isExist = GetUser(user.Id);
            if (isExist == null)
            {
                throw new NullReferenceException("No user was found with this id");
            }
            isExist.Email = user.Email;
            isExist.Name = user.Name;
        }
    }
}
