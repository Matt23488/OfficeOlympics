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
    
    public partial class Witness
    {
        public int Id { get; set; }
        public int CompetitorId { get; set; }
        public int RecordId { get; set; }
    
        public virtual Competitor Competitor { get; set; }
        public virtual Record Record { get; set; }
    }
}