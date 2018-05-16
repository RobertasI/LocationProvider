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

        public User Get(int id)
        {
            using (var context = new LocationProviderContext())
            {
                return context.User.FirstOrDefault(a => a.Id == id);
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
