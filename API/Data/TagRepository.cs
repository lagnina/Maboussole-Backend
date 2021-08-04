using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class TagRepository : ITagRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public TagRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> AddTag(Tag tag)
        {
            var existingTag =  await _context.Tags.Where(t => t.name == tag.name).FirstOrDefaultAsync();
            if(existingTag == null)
            {
                _context.Tags.Add(tag);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
public async Task<Tag> GetTag(string name)
        {
            var existingTag =  await _context.Tags.Where(t => t.name == name).FirstOrDefaultAsync();
           return existingTag;
        }
        public async Task<ICollection<Tag>> GetAllTags()
        {
            return await _context.Tags.ToArrayAsync();
        }

        
    }
}
