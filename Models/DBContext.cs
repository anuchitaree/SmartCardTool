using System.Data.Entity;

namespace SmartCardTool.Models
{
    public class DBContext : DbContext
    {
        public DBContext()
         : base("AppDatabaseConnectionString")
        {
            //this.schema = schema;
        }

        public DbSet<Smartcard> Smartcards { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema("public");
            base.OnModelCreating(builder);
        }

        //public DBContext() : base(nameOrConnectionString: "Default")
        //{
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasDefaultSchema("public");
        //}


        //public DbSet<Smartcard> Smartcards { get; set; } = null;





        //private readonly string schema;








    }


}
