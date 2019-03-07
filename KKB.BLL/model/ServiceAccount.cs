using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.model
{
    class ServiceAccount
    {
        List<Account> accounts = new List<Account>();
        public List<Account> GetAccounts()
        {
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(1,3); i++)
            {
                Account account = new Account();
                account.AccountNumber = "KZT" + rnd.Next();
                account.Balance = rnd.Next(10000, 20000);
                account.CreateDate = DateTime.Now.AddMonths(rnd.Next(20, 100) * (-1));
                accounts.Add(account);
            }
            return accounts;
        }
    }
}
