using Medical.Domain.Common;
using Medical.Domain.Enums;

namespace Medical.Domain.Entities;

public class Sale : BaseAuditableEntity<int>
{
    public string? UserId { get; set; }
    public TypeSaleId TypeSaleId { get; set; }
    public string? Serie { get; set; }
    public string? Correlative { get; set; }
    public int ClientId { get; set; }
    public Client? Client { get; set; }
    public int PacientId { get; set; }
    public Pacient? Pacient { get; set; }
    public decimal SubtotalAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsCancelled { get; set; }
    public bool IsVatExempted { get; set; }
    public List<SaleArticle> SaleArticles { get; set; } = new List<SaleArticle>();
}