using AspWebApi.DataContext;
using AspWebApi.Intefaces.Repositories;
using AspWebApi.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace AspWebApi.Repository
{
    public class PostRepository : CommonRepository<PostModel>, Irepository
    {
        public PostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
