using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ITagRepository
    {
        Task<bool> AddTag(Tag tag);
        Task<ICollection<Tag>> GetAllTags();
        
    }
}
