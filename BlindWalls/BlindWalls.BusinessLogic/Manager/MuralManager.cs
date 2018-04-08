using Domain;
using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlindWalls.BusinessLogic.Manager
{
    public class MuralManager
    {
        private IMuralRepository muralRepository;

        public MuralManager(IMuralRepository muralRepository)
        {
            this.muralRepository = muralRepository;
        }

        public IEnumerable<Mural> GetAllMurals()
        {
            return muralRepository.getAll();
        }

        public Mural GetMuralWithId(int id)
        {
            return muralRepository.GetMuralWithId(id);
        }

        public IEnumerable<Mural> GetMuralsWithArtistId(int artistId)
        {
            return muralRepository.GetMuralsWithArtistId(artistId);
        }

        public void DeleteMural(int id)
        {
            muralRepository.DeleteMural(id);
        }
    }
}
