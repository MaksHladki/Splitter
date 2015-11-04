using Data.Converter.Common;
using Data.Model;

namespace Data.Converter
{
    internal class UserConverter:GenericConverter<User, Shared.Model.DTO.User>
    {
        public override Shared.Model.DTO.User Convert(User entityDB)
        {
            return new Shared.Model.DTO.User
            {
                Id = entityDB.Id,
                Email = entityDB.Email,
                FirstName = entityDB.FirstName,
                LastName = entityDB.LastName,
                Login = entityDB.Login,
                Password = entityDB.Password,
            };
        }

        public override User Convert(Shared.Model.DTO.User entityDTO)
        {
            var user = new User
            {
                Id = entityDTO.Id
            };
            return Copy(entityDTO, user);
        }

        public override User Copy(Shared.Model.DTO.User entityDTO, User entityDB)
        {
            entityDB.Email = entityDTO.Email;
            entityDB.FirstName = entityDTO.FirstName;
            entityDB.LastName = entityDTO.LastName;
            entityDB.Login = entityDTO.Login;
            entityDB.Password = entityDTO.Password;
            return entityDB;
        }
    }
}
