using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IMuralRepository
    {
        IEnumerable<Mural> getAll();

        Mural GetMural(string muralName);

        void InsertMural(Mural mural);

        void DeleteMural(int MuralID);

        void SaveChanges();

        Mural GetMuralWithId(int artistId);

        IEnumerable<Mural> GetMuralsWithArtistId(int artistId);
        void SaveEditMural(Mural m);
        IEnumerable<Mural> GetMuralsWithAccountId(int accountId);
    }
}
