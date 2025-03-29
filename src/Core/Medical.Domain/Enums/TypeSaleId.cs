using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeSaleId
{
    [Display(Description = "Recibo")]
    Receipt,
    [Display(Description = "Factura")]
    Invoice
}