using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Concrete
{
    public class IDStrategy : SearchStrategy
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Mural> SearchMuralsWithID(int searchId)
        {
            return context.Murals.Where(m => m.ArtistID == searchId);
        }

        public IEnumerable<Mural> SearchMuralsWithName(string searchParamater)
        {
            throw new NotImplementedException();
        }
    }
}
