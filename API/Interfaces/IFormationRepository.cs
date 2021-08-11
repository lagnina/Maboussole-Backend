

using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IFormationRepository
    {

        void AddFormations(Formation formation);
        Task<Formation> GetFormation(string Name);
        Task<PagedList<FormationDto>> GetFormations(FormationParams formationParams);
        Task<Formation> GetFormationBySecteur( int formationId,int FormationerId);

    }
}