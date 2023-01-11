using AspWebApi.DataContext;
using AspWebApi.Intefaces.Managers;
using AspWebApi.Models;
using AspWebApi.Repository;
using EF.Core.Repository.Manager;

namespace AspWebApi.Manager
{
    public class PostManager : CommonManager<PostModel>, Imanager
    {
        public PostManager(ApplicationDbContext dbContext) : base(new PostRepository(dbContext))
        {
        }

        public ICollection<PostModel> GetAllContainsFilterData(string text)
        {
            text = text.ToLower();
            return Get(c => c.Title.ToLower().Contains(text) || c.Descriptions.ToLower().Contains(text));
        }

        public ICollection<PostModel> GetAllFilterData(string title)
        {
            return Get(c => c.Title.ToLower() == title.ToLower());
        }

        public PostModel GetById(int id)
        {
            return GetFirstOrDefault(c => c.Id == id);
        }

        public ICollection<PostModel> GetPagingData(int page, int pageSize)
        {
            if (page <= 1) {
                page = 0;
            }
            int totalSkip = page * pageSize;
            return GetAll().Skip(totalSkip).Take(pageSize).ToList();
        }
    }
}
