using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeSexId
{
    [Display(Description = "FEMENINO")]
    Female = 1,
    [Display(Description = "MASCULINO")]
    Male = 2
}
