using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFMuralRepository : IMuralRepository
    {
        private EFDbContext context = new EFDbContext();

        public void DeleteMural(int muralID)
        {
            context.Murals.Remove(GetMuralWithId(muralID));
            SaveChanges();
        }

        public IEnumerable<Mural> getAll()
        {
            return context.Murals;
        }

        public Mural GetMural(string username)
        {
            return context.Murals.Where(a => a.MuralName == username).Select(a => a).First();
        }

        public IEnumerable<Mural> GetMuralsWithArtistId(int artistId)
        {
            return context.Murals.Where(m => m.ArtistID == artistId);
        }

        public Mural GetMuralWithId(int muralId)
        {
            return context.Murals.Where(a => a.MuralId == muralId).Select(a => a).First();
        }

        public void InsertMural(Mural mural)
        {
            context.Murals.Add(mural);
            SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void SaveEditMural(Mural m)
        {
            Mural dbEntry = context.Murals.Find(m.MuralId);

            if (dbEntry != null)
            {
                dbEntry.MuralName = m.MuralName;
                dbEntry.MuralDescription = m.MuralDescription;
                dbEntry.ArtistID = m.ArtistID;
                dbEntry.MuralLocation = m.MuralLocation;
            }
            SaveChanges();
        }
    }
}
