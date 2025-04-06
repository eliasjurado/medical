using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeShiftId
{
    [Display(Description = "Mañana")]
    Morning = 1,
    [Display(Description = "Tarde")]
    Afternoon = 2,
    [Display(Description = "Noche")]
    Night = 3
}
