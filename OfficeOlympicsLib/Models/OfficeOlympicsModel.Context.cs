﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OfficeOlympicsDbEntities : DbContext
    {
        public OfficeOlympicsDbEntities()
            : base("name=OfficeOlympicsDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<OlympicEvent> OlympicEvents { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<Competitor> Competitors { get; set; }
        public virtual DbSet<Witness> Witnesses { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
    }
}
