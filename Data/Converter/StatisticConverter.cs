using Data.Converter.Common;
using Shared.Model.DTO;

namespace Data.Converter
{
    internal class StatisticConverter:GenericConverter<Model.Statistic, Statistic>
    {
        public override Statistic Convert(Model.Statistic entityDB)
        {
            return new Statistic
            {
                Id = entityDB.Id,
                DateOfCreation = entityDB.DateOfCreation,
                HostIP = entityDB.HostIP,
                Referrer = entityDB.Referrer,
                Rule = new RuleConverter().Convert(entityDB.Rule),
                RuleId = entityDB.RuleId,
                UserAgent = entityDB.UserAgent
            };
        }

        public override Model.Statistic Convert(Statistic entityDTO)
        {
            var statistic = new Model.Statistic
            {
                Id = entityDTO.Id
            };
            return Copy(entityDTO, statistic);
        }

        public override Model.Statistic Copy(Statistic entityDTO, Model.Statistic entityDB)
        {
            entityDB.DateOfCreation = entityDTO.DateOfCreation;
            entityDB.HostIP = entityDTO.HostIP;
            entityDB.Referrer = entityDTO.Referrer;
            entityDB.RuleId = entityDTO.RuleId;
            entityDB.UserAgent = entityDTO.UserAgent;
            return entityDB;
        }
    }
}
