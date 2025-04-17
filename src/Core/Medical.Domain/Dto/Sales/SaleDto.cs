using Medical.Domain.Entities;
using Medical.Domain.Enums;

namespace Medical.Domain.Dto.Sales;

public class SaleDto
{
    public int Id { get; set; }
    public TypeSaleId TypeSaleId { get; set; }
    public string? Serie { get; set; }
    public string? Correlative { get; set; }
    public int ClientId { get; set; }
    public Client? Client { get; set; }
    public string? ClientFullName { get; set; }
    public int PacientId { get; set; }
    public Pacient? Pacient { get; set; }
    public string? PacientFullName { get; set; }
    public decimal SubtotalAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsCancelled { get; set; }
    public bool IsVatExempted { get; set; }
    public DateTime SaleDateTime { get; set; } = DateTime.Now;
    public List<SaleArticle> SaleArticles { get; set; } = new List<SaleArticle>();
    public bool IsActive { get; set; } = true;
    public bool Editing { get; set; } = false;
    public bool IsNew { get; set; } = false;
}
