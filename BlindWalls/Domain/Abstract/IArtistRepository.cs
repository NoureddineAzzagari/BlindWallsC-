using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> getAll();

        Artist GetArtist(string username);

        void InsertArtist(Artist artist);

        void SaveChanges();

        Artist GetArtistWithId(int artistId);
        Artist GetArtistWithAccountId(int accountId);
    }
}
