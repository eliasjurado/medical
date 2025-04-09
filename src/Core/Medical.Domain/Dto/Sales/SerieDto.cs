using Medical.Domain.Entities;
using Medical.Domain.Enums;

namespace Medical.Domain.Dto.Sales
{
    public class SerieDto
    {
        public int Id { get; set; }
        public TypeSaleId TypeSaleId { get; set; }
        public int NumSerie { get; set; }
        public int NumCorrelative { get; set; }
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public string? AppUserUserId { get; set; }
        public string? AppUserEmail { get; set; }
        public string? AppUserFirstName { get; set; }
        public string? AppUserLastName { get; set; }
        public TypeDocumentId AppUserTypeDocumentId { get; set; }
        public string? AppUserNumDocument { get; set; }
        public bool AppUserIsTaxExempted { get; set; }
        public bool IsActive { get; set; } = true;
        public bool Editing { get; set; } = false;
        public bool IsNew { get; set; } = false;
    }
}
