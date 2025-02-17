using Medical.Domain.Common;

namespace Medical.Domain.Entities;

public class FiscalProduct : BaseAuditableEntity<int>
{
    public string? Code { get; set; }
    public string? ClassCode { get; set; }
    public string? Name { get; set; }
}
