using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeSaleId
{
    [Display(Description = "BOLETA")]
    Receipt = 1,
    [Display(Description = "FACTURA")]
    Invoice = 2
}