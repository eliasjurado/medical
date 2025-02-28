using Medical.Domain.Common;

namespace Medical.Domain.Entities;

public class Article : BaseAuditableEntity<int>
{
    public string? Name { get; set; }
    public string? CommonName { get; set; }
    public string? Description { get; set; }
    public int FiscalProductId { get; set; }
    public virtual FiscalProduct? FiscalProduct { get; set; }
    public int BrandId { get; set; }
    public virtual Brand? Brand { get; set; }
    public string? Code { get; set; }
    public int FiscalUnitId { get; set; }
    public virtual FiscalUnit? FiscalUnit { get; set; }
    public decimal Cost { get; set; } = 1;
    public decimal MinimumStock { get; set; }
    public decimal Size { get; set; }
    public decimal NetPrice { get; set; }
    public bool IsAllowedSale { get; set; }
}
