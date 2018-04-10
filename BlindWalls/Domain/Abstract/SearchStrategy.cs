using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface SearchStrategy
    {
        IEnumerable<Mural> SearchMuralsWithName(string searchParamater);

        IEnumerable<Mural> SearchMuralsWithID(int searchId);
    }
}
