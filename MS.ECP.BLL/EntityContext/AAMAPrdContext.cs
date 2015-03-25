using MS.ECP.Model;
using MS.ECP.Model.CMS;

namespace MS.ECP.Bll.EntityContext
{
    using System;
    using System.Data.Entity;
    using System.Runtime.CompilerServices;

    public class AAMAPrdContext : DbContext
    {
        public AAMAPrdContext()
            : base("name=ConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CmsEvent>().ToTable("CmsEvent");
            modelBuilder.Entity<News>().ToTable("CmsNews");
        }

        public DbSet<MultiNews> AAMANews { get; set; }

        public DbSet<CmsEvent> RecentEvents { get; set; }

        public DbSet<News> UpcomingNews { get; set; }
    }
}
