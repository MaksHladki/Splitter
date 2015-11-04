using System.Collections.Generic;
using Shared.Model.Common;

namespace Shared.Repository.Common
{
    public interface IGenericRepository<DTO> where DTO : BaseEntity
    {
        IEnumerable<DTO> GetAll();
        DTO GetById(params object[] keyValues);
        DTO Add(DTO entity);
        void Delete(DTO entity);
        void DeleteById(params object[] keyValues);
        void Update(DTO entity);
        void Save();
    }
}
