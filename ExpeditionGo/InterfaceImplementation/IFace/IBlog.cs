using ExpeditionGo.DataModel;
using ExpeditionGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpeditionGo.InterfaceImplementation.IFace
{
    public interface IBlog
    {
        BlogLeft GetById(int id);
        IEnumerable<BlogLeft> GetAllBlogLeft();
        Task AddBlogLeft(BlogLeft blog);
        Task DeleteBlog(int Blogid);
    }
}
