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
    
    public partial class OlympicEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OlympicEvent()
        {
            this.Records = new HashSet<Record>();
        }
    
        public int Id { get; set; }
        public string EventName { get; set; }
        public int EventTypeId { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public System.DateTime DateAdded { get; set; }
        public bool IsActive { get; set; }
        public string IconFileName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Record> Records { get; set; }
        public virtual EventType EventType { get; set; }
    }
}
