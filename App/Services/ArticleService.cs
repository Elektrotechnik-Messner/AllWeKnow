using AllWeKnow.App.Database.Models;
using AllWeKnow.App.Repository;

namespace AllWeKnow.App.Services;

public class ArticleService
{

    public Repository<Article?> Articles;

    private string username = null;

    public ArticleService(Repository<Article?> articles)
    {
        Articles = articles;
    }

    public List<Article?> GetAll(int status = 1)
    {

        return Articles.Get().Where(x => x.Status == status).ToList();
    } 
    
    public Article? GetById(int id)
    {
        return Articles.Get().FirstOrDefault(x => x.Id == id)!;
    }

    public Article? GetRandom(int status = 1) {
        
        Random random = new Random();
        Article? randomArticle;
        
        List<int> allIds = Articles.Get().Where(x => x.Status == status).Select(x => x.Id).ToList();
        
        if (allIds.Count == 0) 
            return null;
        
        int randomId = allIds[random.Next(allIds.Count)];

        randomArticle = Articles.Get().FirstOrDefault(x => x.Id == randomId && x.Status == status)!;
        
        
        return randomArticle;
        
    }
}