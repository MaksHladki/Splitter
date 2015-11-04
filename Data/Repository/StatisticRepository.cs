using Data.Converter;
using Data.Model;
using Data.Repository.Common;
using Shared.Repository;

namespace Data.Repository
{
    internal class StatisticRepository:GenericRepository<Model.Statistic,Shared.Model.DTO.Statistic>, IStatisticRepository
    {
        public StatisticRepository(SplitterEntities entities) : base(entities, new StatisticConverter())
        {
        }

        internal override int GetEntityId(Statistic entityDB)
        {
            return entityDB.Id;
        }

        internal override int GetEntityId(Shared.Model.DTO.Statistic entityDTO)
        {
            return entityDTO.Id;
        }
    }
}
