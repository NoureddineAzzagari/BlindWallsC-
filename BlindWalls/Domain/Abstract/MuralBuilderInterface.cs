using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface MuralBuilderInterface
    {
        void buildArtistAccountWithRequiredParameters(string muralName, string muralDescription, int artistId);

        void buildArtistWithOptionalParameters(string muralLocation);

        Mural GetBuildedMural();
    }
}
