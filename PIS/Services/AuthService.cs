using System.Linq;

namespace PIS.Services
{
    internal class AuthService
    {
        internal static bool Login(string username, string password)
        {
            var user = Program.Db.Users.FirstOrDefault(u => u.Username == username);
            return user != null && BCrypt.Net.BCrypt.Verify(password, user.Password);
        }
    }
}