using Medical.Domain.Entities;
using Medical.Domain.Enums;

namespace Medical.Domain.Dto.Sales;

public class ArticleStockDto
{
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public Article? Article { get; set; }
    public string? ArticleName { get; set; }
    public string? BarCode { get; set; }
    public DateTime ExpireDate { get; set; }
    public int Quantity { get; set; }
    public int WarehouseId { get; set; }
    public Warehouse? Warehouse { get; set; }
    public string? WarehouseName { get; set; }
    public int ShelfNumber { get; set; }
    public int ShelfRowNumber { get; set; }
    public int ShelfColumnNumber { get; set; }
    public TypeArticleStockActionId TypeArticleStockActionId { get; set; }
    public DateTime InventoryDateTime { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
    public bool Editing { get; set; } = false;
    public bool IsNew { get; set; } = false;
}
