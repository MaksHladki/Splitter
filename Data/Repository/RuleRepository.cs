using Data.Converter;
using Data.Model;
using Data.Repository.Common;
using Shared.Repository;
using Rule = Shared.Model.DTO.Rule;

namespace Data.Repository
{
    internal class RuleRepository:GenericRepository<Model.Rule,Rule>, IRuleRepository
    {
        public RuleRepository(SplitterEntities entities) : base(entities, new RuleConverter())
        {
        }

        internal override int GetEntityId(Model.Rule entityDB)
        {
            return entityDB.Id;
        }

        internal override int GetEntityId(Rule entityDTO)
        {
            return entityDTO.Id;
        }
    }
}
