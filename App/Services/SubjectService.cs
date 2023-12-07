using AllWeKnow.App.Database.Models;
using AllWeKnow.App.Repository;

namespace AllWeKnow.App.Services;

public class SubjectService
{
    public Repository<Subject> Subjects;

    public SubjectService(Repository<Subject> subjects)
    {
        Subjects = subjects;
    }

    public List<Subject> GetAll()
    {
        return Subjects.Get().ToList();
    }

    public Subject GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void New(string name)
    {
        if (string.IsNullOrEmpty(name)) 
            return;
        
        
        Subject newsubjetct = new Subject()
        {
            Name = name
        };

        Subjects.Add(newsubjetct);

    }
}