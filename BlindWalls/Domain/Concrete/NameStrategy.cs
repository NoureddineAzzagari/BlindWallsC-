using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Concrete
{
    public class NameStrategy : SearchStrategy
    {

        private EFDbContext context = new EFDbContext();

        public IEnumerable<Mural> SearchMuralsWithID(int searchId)
        {
            return null;
        }

        public IEnumerable<Mural> SearchMuralsWithName(string searchParamater)
        {
            return context.Murals.Where(m => m.MuralName == searchParamater);
        }
    }
}
