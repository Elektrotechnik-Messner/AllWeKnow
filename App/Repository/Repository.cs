/*
 * Date: 2023-11-28
 * 
 * Code from https://github.com/Moonlight-Panel/Moonlight
 * 
 * LICENSE.md https://github.com/Moonlight-Panel/Moonlight/blob/main/LICENSE.md
 */

using AllWeKnow.App.Database;
using Microsoft.EntityFrameworkCore;

namespace AllWeKnow.App.Repository;

public class Repository<TEntity> where TEntity : class
{
    private readonly DataContext DataContext;
    private readonly DbSet<TEntity> DbSet;

    public Repository(DataContext dbContext)
    {
        DataContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        DbSet = DataContext.Set<TEntity>();
    }

    public DbSet<TEntity> Get()
    {
        return DbSet;
    }

    public TEntity Add(TEntity entity)
    {
        var x = DbSet.Add(entity);
        DataContext.SaveChanges();
        return x.Entity;
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
        DataContext.SaveChanges();
    }
    
    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
        DataContext.SaveChanges();
    }
}