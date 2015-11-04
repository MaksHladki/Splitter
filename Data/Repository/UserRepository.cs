using System.Linq;
using Data.Converter;
using Data.Model;
using Data.Repository.Common;
using Shared.Repository;

namespace Data.Repository
{
    internal class UserRepository : GenericRepository<User, Shared.Model.DTO.User>, IUserRepository
    {
        public UserRepository(SplitterEntities entities)
            : base(entities, new UserConverter())
        {
        }

        internal override int GetEntityId(User entityDB)
        {
            return entityDB.Id;
        }

        internal override int GetEntityId(Shared.Model.DTO.User entityDTO)
        {
            return entityDTO.Id;
        }

        public Shared.Model.DTO.User GetByLogin(string login)
        {
            var user = Entities.Users.FirstOrDefault(u => u.Login == login);
            return user != null ? Converter.Convert(user) : null;
        }
    }
}
