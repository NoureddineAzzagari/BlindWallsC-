using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFAccountRepository : IAccountRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Account> GetAll()
        {
            return context.Accounts;
        }

        public Account GetAccount(string username)
        {
            try
            {
                return context.Accounts.Where(a => a.Username == username).Select(a => a).First();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void InsertAccount(Account account)
        {
            account.RoleID = 1;
            context.Accounts.Add(account);
            SaveChanges();
        }

        public Account GetAccountWithId(int accountId)
        {
            try
            {
                return context.Accounts.Where(a => a.AccountID == accountId).Select(a => a).First();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
