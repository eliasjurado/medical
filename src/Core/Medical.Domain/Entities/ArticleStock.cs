using Medical.Domain.Common;
using Medical.Domain.Enums;

namespace Medical.Domain.Entities;

public class ArticleStock : BaseAuditableEntity<int>
{
    public int ArticleId { get; set; }
    public Article? Article { get; set; }
    public int Quantity { get; set; }
    public int WarehouseId { get; set; }
    public Warehouse? Warehouse { get; set; }
    public TypeArticleStockActionId TypeArticleStockActionId { get; set; }
    public DateTime InventoryDateTime { get; set; }
}
