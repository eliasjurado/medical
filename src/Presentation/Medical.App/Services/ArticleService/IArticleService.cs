using Medical.Domain.Dto.Sales;

namespace Medical.App.Services.ArticleService;

public interface IArticleService
{
    event Action OnChange;
    List<ArticleDto> Articles { get; set; }
    List<ArticleDto> AdminArticles { get; set; }
    Task GetArticles();
    Task<ArticleDto?> GetArticleByName(string name);
    Task GetAdminArticles();
    Task AddArticle(ArticleDto item);
    Task UpdateArticle(ArticleDto item);
    Task DeleteArticle(int itemId);
    ArticleDto CreateNewArticle();
}
