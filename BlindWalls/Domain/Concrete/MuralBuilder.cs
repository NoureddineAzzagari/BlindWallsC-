using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class MuralBuilder : MuralBuilderInterface
    {
        private Mural mural = new Mural();

        public void buildArtistAccountWithRequiredParameters(string muralName, string muralDescription, int artistId)
        {
            mural.MuralName = muralName;
            mural.MuralDescription = muralDescription;
        }

        public void buildArtistWithOptionalParameters(string muralLocation)
        {
            mural.MuralLocation = muralLocation;
        }

        public Mural GetBuildedMural()
        {
            return mural;
        }
    }
}
