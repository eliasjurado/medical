using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeArticleId
{
    [Display(Description = "PRODUCCION - CON CONTROL DE STOCK")]
    ProductionWithStockControl = 1,
    [Display(Description = "PRODUCCION - SIN CONTROL DE STOCK")]
    ProductionWithOutStockControl = 2,
    [Display(Description = "PRODUCTOS AJENOS AL TIPO DE NEGOCIO")]
    NonRelatedToBusiness = 3,
    [Display(Description = "COMPRAR PARA VENDER")]
    ForSale = 4,
    [Display(Description = "INSUMOS")]
    Input = 5,
}
