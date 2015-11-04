using System;
using Shared.Model.Common;

namespace Shared.Model.DTO
{
    public class Statistic : Entity<int>
    {
        public string UserAgent { get; set; }
        public string Referrer { get; set; }
        public string HostIP { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int RuleId { get; set; }

        public virtual Rule Rule { get; set; }
    }
}
