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
        public int Id { get; set; }
        public string RecordHolder { get; set; }
        public int OlympicEventId { get; set; }
        public int Score { get; set; }
        public System.DateTime DateAchieved { get; set; }
    
        public virtual OlympicEvent OlympicEvent { get; set; }
    }
}
