using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeSaleId
{
    [Display(Description = "NOTA DE VENTA")]
    Note = 0,
    [Display(Description = "BOLETA")]
    Receipt = 1,
    [Display(Description = "FACTURA")]
    Invoice = 2
}