using Domain.Abstract;
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

        public IEnumerable<Mural> getAll()
        {
            return context.Murals;
        }

        public Mural GetMural(string username)
        {
            return context.Murals.Where(a => a.MuralName == username).Select(a => a).First();
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
    }
}
