//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rule()
        {
            this.Statistics = new HashSet<Statistic>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public System.DateTime DateOfCreation { get; set; }
        public string ShortUrl { get; set; }
        public string MobileUrl { get; set; }
        public string DesktopUrl { get; set; }
        public string DomainUrl { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Statistic> Statistics { get; set; }
    }
}
