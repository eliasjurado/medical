using System.Reflection;

namespace Medical.Server.Contexts
{
    public class PersistenceDataContext : DbContext
    {
        public PersistenceDataContext(DbContextOptions<PersistenceDataContext> options) : base(options)
        {
        }

        //public DbSet<Product> Products { get; set; }
        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Category> Categories { get; set; }

        //public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacient>()
                .HasIndex(u => u.NumDocument).IsUnique();

            //modelBuilder.Entity<CartItem>()
            //    .HasKey(ci => new { ci.UserId, ci.ProductId, ci.ProductTypeId });

            //modelBuilder.Entity<ProductVariant>()
            //    .HasKey(p => new { p.ProductId, p.ProductTypeId });

            //modelBuilder.Entity<OrderItem>()
            //    .HasKey(oi => new { oi.OrderId, oi.ProductId, oi.ProductTypeId });

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersistenceDataContext).Assembly);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Entity<Address>().HasQueryFilter(x => !x.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }
    }
}
