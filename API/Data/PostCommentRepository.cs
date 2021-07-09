using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class PostCommentRepository : IPostCommentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PostCommentRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public  IEnumerable<PostComment> GetPostComments(int postId)
        {
            return  _context.PostComments.Where(Pl => Pl.CommentedPostId == postId).ToArray();
        }

        public async Task<bool> Comment(PostComment postComment)
        {
            try
            {
                _context.PostComments.Add(postComment);
                _context.SaveChanges();
                return true;
            }catch
            {
                return false;
            }
           
               
            
        }
    }
}