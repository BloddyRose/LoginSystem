using System.Data.Entity;

namespace LoginSystem.Database
{
    public partial class ModelUser : DbContext
    {
        public ModelUser()
            : base("name=ModelUser")
        {
        }

        public virtual DbSet<TableUser> TableUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableUser>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<TableUser>()
                .Property(e => e.Password)
                .IsFixedLength();
        }
    }
}