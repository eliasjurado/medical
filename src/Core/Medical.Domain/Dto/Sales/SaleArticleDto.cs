namespace Medical.Domain.Dto.Sales;

public class SaleArticleDto
{
    public int Id { get; set; }
    public int SaleId { get; set; }
    public SaleDto? Sale { get; set; }
    public int ArticleId { get; set; }
    public ArticleDto? Article { get; set; }
    public string? ArticleName { get; set; }
    public decimal ArticleNetPrice { get; set; }
    public decimal Quantity { get; set; }
    public decimal SubtotalAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsActive { get; set; } = true;
    public bool Editing { get; set; } = false;
    public bool IsNew { get; set; } = false;
}
