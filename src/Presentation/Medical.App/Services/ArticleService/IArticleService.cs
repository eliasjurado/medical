using Medical.Domain.Dto.Article;

namespace Medical.App.Services.ArticleService;

public interface IArticleService
{
    event Action OnChange;
    List<ArticleDto> Articles { get; set; }
    List<ArticleDto> AdminArticles { get; set; }
    Task GetArticles();
    Task GetAdminArticles();
    Task AddArticle(ArticleDto item);
    Task UpdateArticle(ArticleDto item);
    Task DeleteArticle(int itemId);
    ArticleDto CreateNewArticle();
}
