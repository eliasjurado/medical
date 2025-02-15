namespace Medical.Domain.Dto.Brand;

public class BrandDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public bool Editing { get; set; } = false;
    public bool IsNew { get; set; } = false;
}
