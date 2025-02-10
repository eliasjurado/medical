using Medical.Domain.Common;

namespace Medical.Domain.Entities;

public class Treatment : BaseAuditableEntity<int>
{
    public string? Name { get; set; }
    public int DurationMinutes { get; set; } = 30;
    public decimal Cost { get; set; } = 1;
    public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();
}
