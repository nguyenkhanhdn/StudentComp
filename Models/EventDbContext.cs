using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentComp.Models
{
    public class EventDbContext:DbContext
    {
        public EventDbContext() : base("name=DefaultConnection")
        {
            //Database.SetInitializer<EventDbContext>(new DropCreateDatabaseIfModelChanges<EventDbContext>());
            Database.SetInitializer<EventDbContext>(new CreateDatabaseIfNotExists<EventDbContext>());
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Handbook> Handbooks { get; set; }
        public DbSet<Maxim> Maxims { get; set; }
        public DbSet<Read> Reads { get; set; }
        public DbSet<Recommend> Recommends { get; set; }
    }
}