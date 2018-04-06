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
        private IArtistRepository artistRepository = new EFArtistRepository();

        public AuthManager(IArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository;
        }

        public Artist GetArtist(string username, string password)
        {
            return artistRepository.GetArtist(username, password);
        }

        public bool CheckAccountValidity(string username, string password)
        {
            var account = artistRepository.GetArtist(username, password);

            if(account != null)
            {
                var passwordString = account.ArtistPassword;

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


    }
}
