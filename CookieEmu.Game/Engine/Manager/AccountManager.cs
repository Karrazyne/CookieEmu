using System.Linq;
using CookieEmu.Game.SQL.Account;

namespace CookieEmu.Game.Engine.Manager
{
    public class AccountManager
    {
        public static bool ReturnAccount(string username, out Account account)
        {
            using (var context = new AccountModel())
            {
                account = (from a in context.accounts
                    where a.Login == username
                    select a).FirstOrDefault();
                return account != null;
            }
        }

        public static bool ReturnAccountWithTicket(string ticket, out Account account)
        {
            using (var context = new AccountModel())
            {
                account = (from a in context.accounts
                    where a.Ticket == ticket
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
