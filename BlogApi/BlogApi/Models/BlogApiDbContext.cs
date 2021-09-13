using BlogApi.Migrations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace BlogApi.Models
{
    public class BlogApiDbContext : DbContext
    {
        public BlogApiDbContext() : base("BlogApiDb")
        {
           //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogApiDbContext, Configuration>());
        }

        //[JsonIgnore, XmlIgnore]
        public DbSet<User> Users { get; set; }

        //[JsonIgnore, XmlIgnore]
        public DbSet<Post> Posts { get; set; }

        //[JsonIgnore, XmlIgnore]
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

}
