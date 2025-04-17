using Medical.Domain.Common;

namespace Medical.Domain.Entities
{
    public class FiscalTax : BaseAuditableEntity<int>
    {
        public int NumYear { get; set; }
        public decimal TaxAmount { get; set; }
    }
}
