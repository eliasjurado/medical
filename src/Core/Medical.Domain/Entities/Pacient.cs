using Medical.Domain.Common;
using Medical.Domain.Enums;

namespace Medical.Domain.Entities;

public class Pacient : BaseAuditableEntity<int>
{
    public TypeDocumentId TypeDocumentId { get; set; }
    public string? NumDocument { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public TypeSexId TypeSexId { get; set; }
    public DateTime Birthdate { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();
}
