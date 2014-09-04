using System.Data.Entity;
using MS.ECP.Model;
using MS.ECP.Model.CMS;

namespace MS.ECP.Bll.EntityContext
{
    public class AAMAPrdContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<MS.ECP.AAMAPrd.Models.MS.ECP.AAMAPrdContext>());

        public AAMAPrdContext()
            : base("name=ConnectionString")
        {
        }

        public DbSet<MultiNews> MultiNewss { get; set; }
         
    }
}
