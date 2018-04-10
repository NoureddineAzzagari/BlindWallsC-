using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlindWalls.BusinessLogic.Manager
{
    public class AdminManager
    {
        private IMuralRepository muralRepository = new EFMuralRepository();
        private IArtistRepository artistRepository = new EFArtistRepository();
        private SearchStrategy searchStrategy;

        public AdminManager(IMuralRepository muralRepository, IArtistRepository artistRepository)
        {
            this.muralRepository = muralRepository;
            this.artistRepository = artistRepository;
        }

        public IEnumerable<Mural> GetAllMurals()
        {
            return muralRepository.getAll();
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            return artistRepository.getAll();
        }

        public IEnumerable<Mural> GetAllMuralsWithSearchStrategy(string searchParameter, string search)
        {
            if(search == "id")
            {
                int searchId = Int32.Parse(searchParameter);
                searchStrategy = new IDStrategy();
                return searchStrategy.SearchMuralsWithID(searchId);
            } else
            {
                searchStrategy = new NameStrategy();
                return searchStrategy.SearchMuralsWithName(searchParameter);
            }
        }


    }
}
