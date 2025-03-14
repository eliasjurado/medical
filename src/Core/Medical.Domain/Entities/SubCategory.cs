using Medical.Domain.Common;
using Medical.Domain.Enums;

namespace Medical.Domain.Entities;

public class SubCategory : BaseAuditableEntity<int>
{
    public string? Name { get; set; }
    public string? Code { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
