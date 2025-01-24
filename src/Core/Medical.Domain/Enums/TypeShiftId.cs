using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeShiftId
{
    [Display(Description = "Dia")]
    Dia,
    [Display(Description = "Tarde")]
    Tarde,
    [Display(Description = "Noche")]
    Noche
}
