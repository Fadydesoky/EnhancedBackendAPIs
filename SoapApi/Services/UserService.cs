using System.ServiceModel;
using SharedLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace SoapApi.Services
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        List<User> GetAllUsers();

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        User CreateUser(User user);

        [OperationContract]
        User UpdateUser(User user);

        [OperationContract]
        bool DeleteUser(int id);
    }

    public class UserService : IUserService
    {
        private readonly ApiDbContext _context;

        public UserService(ApiDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _context.Users.Find(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }

        public bool DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}