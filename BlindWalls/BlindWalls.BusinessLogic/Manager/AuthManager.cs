using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlindWalls.BusinessLogic
{
    public class AuthManager
    {
        private IAccountRepository accountRepository = new EFAccountRepository();
        private IRoleRepository roleRepository = new EFRoleRepository();
        private IArtistRepository artistRepository = new EFArtistRepository();

        public AuthManager(IAccountRepository accountRepository, IRoleRepository roleRepository, IArtistRepository artistRepository)
        {
            this.accountRepository = accountRepository;
            this.roleRepository = roleRepository;
            this.artistRepository = artistRepository;
        }

        public Account GetAccount(string username)
        {
            return accountRepository.GetAccount(username);
        }

        public bool CheckAccountValidity(string username, string password)
        {
            var account = accountRepository.GetAccount(username);

            if(account != null)
            {
                var passwordString = account.Password;

                if(passwordString == password)
                {
                    return true;
                } else
                {
                    return false;
                }

            }
            return false;
        }

        public Role GetRoleByName(string roleName)
        {
            return roleRepository.GetRoleByName(roleName);
        }

        public Artist GetArtistWithAccountId(int accountId)
        {
            return artistRepository.GetArtistWithAccountId(accountId);
        }
    }
}
