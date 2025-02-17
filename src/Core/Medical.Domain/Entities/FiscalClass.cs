using Medical.Domain.Common;

namespace Medical.Domain.Entities;

public class FiscalClass : BaseAuditableEntity<int>
{
    public string? Code { get; set; }
    public string? FamilyCode { get; set; }
    public string? Name { get; set; }
}
