using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeArticleId
{
    [Display(Description = "PRODUCCION - CON CONTROL DE STOCK")]
    ProductionWithStockControl,
    [Display(Description = "PRODUCCION - SIN CONTROL DE STOCK")]
    ProductionWithOutStockControl,
    [Display(Description = "PRODUCTOS AJENOS AL TIPO DE NEGOCIO")]
    NonRelatedToBusiness,
    [Display(Description = "COMPRAR PARA VENDER")]
    ForSale,
    [Display(Description = "INSUMOS")]
    Input,
}
