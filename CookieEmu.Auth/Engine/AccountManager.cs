using System.Linq;
using CookieEmu.Auth.SQL;

namespace CookieEmu.Auth.Engine
{
    public class AccountManager
    {
        public static bool ReturnAccount(string username, string password, out Account account)
        {
            using (var context = new AccountModel())
            {
                account = (from a in context.accounts
                    where a.Login == username && a.Password == password
                    select a).FirstOrDefault();
                return account != null;
            }
        }

        public static bool NicknameAlreadyExist(string nickname)
        {
            using (var context = new AccountModel())
            {
                var account = (from a in context.accounts
                    where a.Nickname == nickname
                    select a).ToList();

                return account.Count > 0;
            }
        }
    }
}
