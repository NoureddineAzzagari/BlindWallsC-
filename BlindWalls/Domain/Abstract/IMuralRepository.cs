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

        void SaveChanges();

        Mural GetMuralWithId(int artistId);
    }
}
