using Medical.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Medical.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class TypeArticleStockAction
    {
        public TypeArticleStockAction()
        {
        }
        public TypeArticleStockActionId TypeArticleStockActionId { get; set; }

        public string? Name { get; set; }
    }
}
