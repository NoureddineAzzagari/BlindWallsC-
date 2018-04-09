using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();

        Account GetAccount(string username);

        void InsertAccount(Account account, Artist artist);

        void SaveChanges();

        Account GetAccountWithId(int accountId);
    }
}
