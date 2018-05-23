using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using LocationProvider.Domain;

namespace LocationProvider.DataAccess
{
    public class UserDataService
    {
        public List<User> GetAll()
        {
            using (var context = new LocationProviderContext())
            {
                return context.User.ToList();
            }
        }

        public void AddNotExisting(string userId, User u)
        {
            using (var context = new LocationProviderContext())
            {
                var user = context.User.FirstOrDefault(a => a.UserId == userId);
                if (user == null)
                {
                    context.User.AddOrUpdate(u);
                    context.SaveChanges();
                }
            }
        }

        public User Get(int id)
        {
            using (var context = new LocationProviderContext())
            {
                return context.User.FirstOrDefault(a => a.Id == id);
            }
        }

        public User GetByUserId(string userId)
        {
            using (var context = new LocationProviderContext())
            {
                return context.User.FirstOrDefault(a => a.UserId == userId);
            }
        }

        public void Add(User user)
        {
            using (var context = new LocationProviderContext())
            {
                context.User.AddOrUpdate(user);
                context.SaveChanges();
            }
        }

        public void Update(User user)
        {
            using (var context = new LocationProviderContext())
            {
                context.User.AddOrUpdate(user);
                context.SaveChanges();
            }
        }

        public void Remove(User user)
        {
            using (var context = new LocationProviderContext())
            {
                context.User.Remove(user);
                context.SaveChanges();
            }
        }

    }
}
