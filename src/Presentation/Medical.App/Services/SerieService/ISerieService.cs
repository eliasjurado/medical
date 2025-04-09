using Medical.Domain.Dto.Sales;

namespace Medical.App.Services.SerieService;

public interface ISerieService
{
    event Action OnChange;
    List<SerieDto> Series { get; set; }
    List<SerieDto> AdminSeries { get; set; }
    Task GetSeries();
    Task<List<SerieDto>> GetSeriesByUserId(string user);
    Task GetAdminSeries();
    Task AddSerie(SerieDto item);
    Task UpdateSerie(SerieDto item);
    Task DeleteSerie(int itemId);
    SerieDto CreateNewSerie();
}
