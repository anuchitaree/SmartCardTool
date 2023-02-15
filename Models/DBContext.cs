using System.Data.Entity;

namespace SmartCardTool.Models
{
    public class DBContext : DbContext
    {


        public DBContext() : base(nameOrConnectionString: "Default")
        {
        }

        




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
        }
    

        public DbSet<Smartcard> Smartcards { get; set; } = null;




    }


}
