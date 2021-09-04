using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    internal class FormationRepository : IFormationRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public FormationRepository(DataContext context, IMapper mapper)
        {
     _mapper = mapper;
            _context = context;
        }

        public void AddFormations(Formation formation)
        {
_context.Formations.Add(formation);        }

        public Task<Formation> GetFormation(string Name)
        {

           return  _context.Formations.Where(p =>p.Name == Name).SingleOrDefaultAsync();
        }

        public Task<Formation> GetFormationBySecteur(int formationId, int FormationId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PagedList<FormationDto>> GetFormations(FormationParams formationParams)
        {
            var query = _context.Formations.AsQueryable();
            
            
            if (formationParams.Domaine != null && formationParams.Domaine != "")
          
            {
                 query = query.Where(p => p.Domaine.ToLower().Contains(formationParams.Domaine.ToLower())).AsQueryable();
            }

            if (formationParams.Ville != null && formationParams.Ville != "")

            {
                query = query.Where(p => p.Ville.ToLower().Contains(formationParams.Ville.ToLower())).AsQueryable();
            }
            if (formationParams.Etablissement != null && formationParams.Etablissement != "")

            {
                query = query.Where(p => p.Etablissement.ToLower().Contains(formationParams.Etablissement.ToLower())).AsQueryable();
            }
            if (formationParams.Secteur != null && formationParams.Secteur != "")

            {
                query = query.Where(p => p.Secteur.ToLower().Contains(formationParams.Secteur.ToLower())).AsQueryable();
            }






            return await PagedList<FormationDto>.CreateAsync(query.ProjectTo<FormationDto>(_mapper
                .ConfigurationProvider).AsNoTracking(), 
                    formationParams.PageNumber, formationParams.PageSize);        }

       
    }

}
