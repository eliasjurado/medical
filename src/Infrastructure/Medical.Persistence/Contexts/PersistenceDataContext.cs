using Medical.Domain.Enums;
using System.Reflection;

namespace Medical.Server.Contexts
{
    public class PersistenceDataContext : DbContext
    {
        public PersistenceDataContext(DbContextOptions<PersistenceDataContext> options) : base(options)
        {
        }

        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeAppointment>()
                .HasData(
                    Enum.GetValues(typeof(TypeAppointmentId))
                        .Cast<TypeAppointmentId>()
                        .Select(e => new TypeAppointment()
                        {
                            TypeAppointmentId = e,
                            Name = e.ToString()
                        })
                );

            modelBuilder.Entity<TypeDocument>()
                .HasData(
                    Enum.GetValues(typeof(TypeDocumentId))
                        .Cast<TypeDocumentId>()
                        .Select(e => new TypeDocument()
                        {
                            TypeDocumentId = e,
                            Name = e.ToString()
                        })
                );

            modelBuilder.Entity<TypeSex>()
                .HasData(
                    Enum.GetValues(typeof(TypeSexId))
                        .Cast<TypeSexId>()
                        .Select(e => new TypeSex()
                        {
                            TypeSexId = e,
                            Name = e.ToString()
                        })
                );

            modelBuilder.Entity<TypeShift>()
                .HasData(
                    Enum.GetValues(typeof(TypeShiftId))
                        .Cast<TypeShiftId>()
                        .Select(e => new TypeShift()
                        {
                            TypeShiftId = e,
                            Name = e.ToString()
                        })
                );
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
