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

        public Task<Formation> GetFormation(int id)
        {

           return  _context.Formations.Where(p =>p.Id == id).SingleOrDefaultAsync();
        }

        public Task<Formation> GetFormationBySecteur(int formationId, int FormationerId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PagedList<FormationDto>> GetFormations(FormationParams formationParams)
        {
            IQueryable<Formation> query;
            if(formationParams.Domaine == null)
            {
                 query = _context.Formations.AsQueryable();
            }
            else
            {
                 query = _context.Formations.Where(p => p.Domaine == formationParams.Domaine).AsQueryable();
            }
 
           


            
            return await PagedList<FormationDto>.CreateAsync(query.ProjectTo<FormationDto>(_mapper
                .ConfigurationProvider).AsNoTracking(), 
                    formationParams.PageNumber, formationParams.PageSize);        }

       
    }

}