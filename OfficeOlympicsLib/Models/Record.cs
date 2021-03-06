//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OfficeOlympicsLib.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Record
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Record()
        {
            this.Witnesses = new HashSet<Witness>();
        }
    
        public int Id { get; set; }
        public int OlympicEventId { get; set; }
        public int Score { get; set; }
        public System.DateTime DateAchieved { get; set; }
        public int CompetitorId { get; set; }
    
        public virtual OlympicEvent OlympicEvent { get; set; }
        public virtual Competitor Competitor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Witness> Witnesses { get; set; }
    }
}
