using AllWeKnow.App.Database.Models;
using AllWeKnow.App.Repository;

namespace AllWeKnow.App.Services;

public class ArticleService
{
    public Repository<Article> Articles;

    public ArticleService(Repository<Article> articles)
    {
        Articles = articles;
    }

    public List<Article> GetAll()
    {
        return Articles.Get().ToList();
    } 
    
    public Article GetById(int id)
    {
        return Articles.Get().FirstOrDefault(x => x.Id == id);
    }     
}