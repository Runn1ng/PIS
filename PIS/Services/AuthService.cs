using System.Linq;
using System.Threading.Tasks;
using PIS.Models;

namespace PIS.Services
{
    internal class AuthService
    {
        internal static User Login(string username, string password)
        {
            var user =
                Program.Db.Users.FirstOrDefault(u => u.Username == username);
            if (user != null &&
                BCrypt.Net.BCrypt.Verify(password, user.Password))
                return user;
            return null;
        }

        internal static async Task CreateUser(User user)
        {
            Program.Db.Users.Add(user);
            await Program.Db.SaveChangesAsync();
        }
    }
}