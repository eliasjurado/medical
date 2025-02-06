using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeSexId
{
    [Display(Description = "Femenino")]
    Female,
    [Display(Description = "Masculino")]
    Male
}
