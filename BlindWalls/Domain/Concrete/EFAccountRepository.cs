﻿using Domain.Abstract;
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
            account.RoleID = 2;
            context.Accounts.Add(account);
            SaveChanges();
            Account inserted = context.Accounts.OrderByDescending(o => o.AccountID).FirstOrDefault();
            Artist artist = new Artist();
            artist.ArtistName = inserted.Username;
            artist.Account = inserted;
            context.Artists.Add(artist);
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
