using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeDocumentId
{
    [Display(Description = "DNI")]
    DNI = 1,
    [Display(Description = "RUC")]
    RUC = 2,
    [Display(Description = "CE")]
    CE = 3,
    [Display(Description = "PASAPORTE")]
    Passport = 4
}
