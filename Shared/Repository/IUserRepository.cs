using Shared.Model.DTO;
using Shared.Repository.Common;

namespace Shared.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByLogin(string login);
    }
}
