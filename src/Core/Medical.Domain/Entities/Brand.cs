using Medical.Domain.Common;

namespace Medical.Domain.Entities;

public class Brand : BaseAuditableEntity<int>
{
    public string? Name { get; set; }
}
