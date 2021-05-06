using ExpeditionGo.Data;
using ExpeditionGo.InterfaceImplementation.IFace;
using ExpeditionGo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpeditionGo.InterfaceImplementation
{
    public class BlogImplementationcs : IBlog
    {
        private readonly ApplicationDbContext _context;

        public BlogImplementationcs(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddBlogLeft(BlogLeft blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
        }

        public Task DeleteBlog(int Blogid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogLeft> GetAllBlogLeft()
        {
            return _context.Blogs;
        }

        public BlogLeft GetByBlogLeftId(int id)
        {
            return _context.Blogs.Where(q => q.BlogLeftId == id)
               .First();
        }

        public BlogLeft GetById(int id)
        {
            return _context.Blogs.Where(q => q.BlogLeftId == id)
               .First();
        }
    }
}
