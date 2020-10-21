using Microsoft.EntityFrameworkCore.Internal;
using SharedTrip.Models;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string CreateUser(string username, string email, string password)
        {
            var user = new User()
            {
                Username = username,
                Email = email,
                Password = ComputeHash(password),
            };

            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();
            
            return user.Id;
        }

        public string GetUserId(LoginInputModel model)
        {
            var user = this.dbContext.Users.FirstOrDefault(x => x.Username == model.username);

            if (user == null || user.Password != ComputeHash(model.password))
            {
                return null;
            }

            return user?.Id; 
        }

        public bool IsEmailAvailable(string email)
        {
            return !this.dbContext.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return !this.dbContext.Users.Any(x => x.Username == username);
        }

        public static string ComputeHash(string input)
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
