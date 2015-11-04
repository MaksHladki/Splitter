using System.Collections.Generic;
using Shared.Model.Common;

namespace Shared.Model.DTO
{
    public class Rule : Entity<int>
    {
        public string Title { get; set; }
        public System.DateTime DateOfCreation { get; set; }
        public string ShortUrl { get; set; }
        public string MobileUrl { get; set; }
        public string DesktopUrl { get; set; }
        public string DomainUrl { get; set; }

        public virtual ICollection<Statistic> Statistics { get; set; }
    }
}
