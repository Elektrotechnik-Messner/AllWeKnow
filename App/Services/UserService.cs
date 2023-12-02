using AllWeKnow.App.Database.Models;
using AllWeKnow.App.Repository;

namespace AllWeKnow.App.Services;

public class UserService
{
    public Repository<User> Users;

    public UserService(Repository<User> users)
    {
        Users = users;
    }

    public List<User> GetAllUsers()
    {
        return Users.Get().ToList();
    } 
    
    public User GetUserById(int id)
    {
        return Users.Get().FirstOrDefault(x => x.Id == id);
    }                               
}