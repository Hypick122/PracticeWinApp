using PracticeWinApp.Database;
using System.Linq;

namespace PracticeWinApp.Utils
{
    public static class Registration
    {
        public static bool IsUsernameAvailable(string username)
        {
            using (DbAppContext context = new DbAppContext())
                return context.Set<User>().Any(u => u.Username == username);
        }

        public static bool IsPasswordValid(string password)
        {
            return password.Length >= 6 && password.Any(char.IsDigit) && password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) && password.All(char.IsLetterOrDigit);
        }
    }

    public static class Login
    {
        public static bool IsCredentialsValid(string username, string password)
        {
            using (DbAppContext context = new DbAppContext())
                return context.Set<User>().Any(u => u.Username == username && u.Password == password);
        }
    }
}
