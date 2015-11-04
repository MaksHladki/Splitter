using Data.Converter.Common;
using Data.Model;

namespace Data.Converter
{
    internal class RuleConverter:GenericConverter<Rule, Shared.Model.DTO.Rule>
    {
        public override Shared.Model.DTO.Rule Convert(Rule entityDB)
        {
            return new Shared.Model.DTO.Rule
            {
                Id = entityDB.Id,
                DateOfCreation = entityDB.DateOfCreation,
                DesktopUrl = entityDB.DesktopUrl,
                DomainUrl = entityDB.DomainUrl,
                MobileUrl = entityDB.MobileUrl,
                ShortUrl = entityDB.ShortUrl,
                //Statistics = TO DO
            };
        }

        public override Rule Convert(Shared.Model.DTO.Rule entityDTO)
        {
            var rule = new Rule
            {
                Id = entityDTO.Id
            };
            return Copy(entityDTO, rule);
        }

        public override Rule Copy(Shared.Model.DTO.Rule entityDTO, Rule entityDB)
        {
            entityDB.DateOfCreation = entityDTO.DateOfCreation;
            entityDB.DesktopUrl = entityDTO.DesktopUrl;
            entityDB.MobileUrl = entityDTO.MobileUrl;
            entityDB.DomainUrl = entityDTO.DomainUrl;
            entityDB.ShortUrl = entityDTO.ShortUrl;
            entityDB.Title = entityDTO.Title;
            //Statistics TO DO
            return entityDB;
        }
    }
}
