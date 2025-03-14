using Medical.Domain.Entities;

namespace Medical.Domain.Dto.Sales;

public class ArticleDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? CommonName { get; set; }
    public string? Description { get; set; }
    public int SubCategoryId { get; set; }
    public virtual SubCategory? SubCategory { get; set; }
    public string? SubCategoryName { get; set; }
    public int FiscalProductId { get; set; }
    public virtual FiscalProduct? FiscalProduct { get; set; }
    public string? FiscalProductName { get; set; }
    public int BrandId { get; set; }
    public virtual Entities.Brand? Brand { get; set; }
    public string? BrandName { get; set; }
    public string? Code { get; set; }
    public int FiscalUnitId { get; set; }
    public virtual FiscalUnit? FiscalUnit { get; set; }
    public string? FiscalUnitName { get; set; }
    public decimal Cost { get; set; }
    public decimal Stock { get; set; }
    public decimal MinimumStock { get; set; }
    public decimal Size { get; set; }
    public decimal NetPrice { get; set; }
    public bool IsAllowedSale { get; set; } = true;
    public bool IsActive { get; set; } = true;
    public bool Editing { get; set; } = false;
    public bool IsNew { get; set; } = false;
}
