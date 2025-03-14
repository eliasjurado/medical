using Medical.Domain.Common;

namespace Medical.Domain.Entities;

public class Warehouse : BaseAuditableEntity<int>
{
    public string? Name { get; set; }
}
