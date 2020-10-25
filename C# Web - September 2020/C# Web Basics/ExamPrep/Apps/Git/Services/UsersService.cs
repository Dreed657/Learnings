using Git.Data;
using Git.Data.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Git.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateUser(string username, string email, string password)
        {
            var entity = new User()
            {
                Username = username,
                Email = email,
                Password = ComputeHash(password),
            };

            this.db.Users.Add(entity);
            this.db.SaveChanges();

            return entity?.Id;
        }

        public string GetUserId(string username, string password)
        {
            var entity = this.db.Users.FirstOrDefault(x => x.Username == username);

            if(entity == null || entity.Password != ComputeHash(password))
            {
                return null;
            }

            return entity?.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return !this.db.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return !this.db.Users.Any(x => x.Username == username);
        }

        private static string ComputeHash(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using var hash = System.Security.Cryptography.SHA512.Create();

            var hashedInputBytes = hash.ComputeHash(bytes);
            var hashedInputStringBuilder = new System.Text.StringBuilder(128);

            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));

            return hashedInputStringBuilder.ToString();
        }
    }
}
