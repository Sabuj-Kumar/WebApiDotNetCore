using AspWebApi.Models;
using EF.Core.Repository.Interface.Repository;

namespace AspWebApi.Intefaces.Repositories
{
    public interface Irepository:ICommonRepository<PostModel>
    {
    }
}
