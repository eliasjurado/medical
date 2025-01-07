using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(p => p.Pacient)
            .WithMany(o => o.Appointments)
            .HasForeignKey(q => q.IdPacient)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Specialist)
            .WithMany(o => o.Appointments)
            .HasForeignKey(q => q.IdSpecialist)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Treatment)
            .WithMany(o => o.Appointments)
            .HasForeignKey(q => q.IdTreatment)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(x => !x.IsDeleted);

    }
}
