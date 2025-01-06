using Medical.Domain.Common;

namespace Medical.Domain.Entities;

public class Treatment : BaseAuditableEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
}
