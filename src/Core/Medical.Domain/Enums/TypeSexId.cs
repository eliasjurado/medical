using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeSexId
{
    [Display(Description = "Femenino")]
    Female = 1,
    [Display(Description = "Masculino")]
    Male = 2
}
