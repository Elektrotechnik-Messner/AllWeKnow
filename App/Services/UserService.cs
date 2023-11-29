using AllWeKnow.App.Database.Models;
using AllWeKnow.App.Repository;

namespace AllWeKnow.App.Services;

public class UserService
{
    public Repository<User> Users;

    public List<User> GetAllUsers()
    {
        return Users.Get().ToList();
    }
}