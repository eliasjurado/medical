using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;
public enum TypeDocumentId
{
    [Display(Description = "DNI")]
    DNI,
    [Display(Description = "CI")]
    CI,
    [Display(Description = "CE")]
    CE,
    [Display(Description = "Pasaporte")]
    Pasaporte
}
