using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeArticleStockActionId
{
    [Display(Description = "Carga Inicial")]
    InitialLoad,
    [Display(Description = "Compra")]
    Purchase,
    [Display(Description = "Devolución")]
    Return,
    [Display(Description = "Venta")]
    Sale,
    [Display(Description = "Retiro")]
    Withdrawal,
    [Display(Description = "Merma")]
    Wastage
}
