using Medical.Domain.Common;

namespace Medical.Domain.Entities
{
    public class SaleArticle : BaseAuditableEntity<int>
    {
        public int SaleId { get; set; }
        public Sale? Sale { get; set; }
        public int ArticleId { get; set; }
        public Article? Article { get; set; }
        public decimal Quantity { get; set; }
        public decimal SubtotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}