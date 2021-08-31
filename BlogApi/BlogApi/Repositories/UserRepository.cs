using BlogApi.Models;
using BlogApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApi.Repositories
{
    public class UserRepository : Repository<User>
    {

        BlogApiDbContext context = new BlogApiDbContext();
        public User GetUsernamePass(string username,string password)
        {
           User user = new User();
           var getUsername= context.Users.Where(x => x.Username==username).FirstOrDefault();
           var getPassword= context.Users.Where(x => x.Password==password).FirstOrDefault();

            user.Username = getUsername.Username;
            user.Password = getPassword.Password;

            return null;
        }

        public static bool Login(string username, string password)
        {
            using (BlogApiDbContext context = new BlogApiDbContext())
            {
                return context.Users.Any(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && x.Password.Equals(password));
            }

        }


    }
}