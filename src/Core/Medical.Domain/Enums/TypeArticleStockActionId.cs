using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeArticleStockActionId
{
    [Display(Description = "CARGA INICIAL")]
    InitialLoad = 1,
    [Display(Description = "COMPRA")]
    Purchase = 2,
    [Display(Description = "DEVOLUCION")]
    Return = 3,
    [Display(Description = "VENTA")]
    Sale = 4,
    [Display(Description = "RETIRO")]
    Withdrawal = 5,
    [Display(Description = "MERMA")]
    Wastage = 6
}
