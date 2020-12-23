using System.Linq;
using System.Threading.Tasks;
using PIS.Models;

namespace PIS.Services
{
    internal class AuthService
    {
        internal static bool Login(string username, string password)
        {
            var user =
                Program.Db.Users.FirstOrDefault(u => u.Username == username);
            return user != null &&
                   BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

        internal static async Task CreateUser(string username, string password)
        {
            var newUser = new User
            {
                Username = username,
                Password = BCrypt.Net.BCrypt.HashPassword(password,
                    BCrypt.Net.BCrypt.GenerateSalt(12)),
                Role_id = 1,
                Locality_id = 1,
            };
            Program.Db.Users.Add(newUser);
            await Program.Db.SaveChangesAsync();
        }
    }
}