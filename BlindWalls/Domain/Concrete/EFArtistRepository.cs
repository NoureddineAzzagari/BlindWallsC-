using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFArtistRepository : IArtistRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Artist> getAll()
        {
            return context.Artists;
        }

        public Artist GetArtist(string muralName)
        {
            return context.Artists.Where(a => a.ArtistName == muralName).Select(a => a).First();
        }

        public Artist GetArtistWithId(int artistId)
        {
            return context.Artists.Where(a => a.ArtistID == artistId).Select(a => a).First();
        }

        public void InsertArtist(Artist artist)
        {
            context.Artists.Add(artist);
            SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
