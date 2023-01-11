using AspWebApi.Models;
using EF.Core.Repository.Interface.Manager;

namespace AspWebApi.Intefaces.Managers
{
    public interface Imanager:ICommonManager<PostModel>
    {
        PostModel GetById(int id);
        ICollection<PostModel> GetAllFilterData(string title);
        ICollection<PostModel> GetAllContainsFilterData(string text);
        ICollection<PostModel> GetPagingData(int page, int pageSize);
    }
}
