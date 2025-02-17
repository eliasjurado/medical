using Medical.Domain.Entities;

namespace Medical.Domain.Dto.Article;

public class ArticleDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? CommonName { get; set; }
    public string? Description { get; set; }
    public int IdFiscalProduct { get; set; }
    public FiscalProduct? FiscalProduct { get; set; }
    public int IdBrand { get; set; }
    public Entities.Brand? Brand { get; set; }
    public string? Code { get; set; }
    public string? UnitCode { get; set; }
    public int IdFiscalUnit { get; set; }
    public FiscalUnit? FiscalUnit { get; set; }
    public decimal Cost { get; set; } = 1;
    public decimal MinimumStock { get; set; }
    public decimal Size { get; set; }
    public decimal Net { get; set; }
    public decimal MinimumNet { get; set; }
    public bool IsAllowedSale { get; set; }
    public bool IsActive { get; set; } = true;
    public bool Editing { get; set; } = false;
    public bool IsNew { get; set; } = false;
}
