using Roniroid.Basics.EF.Data;
using Entities = Roniroid.Basics.EF.Entities;

namespace Roniroid.Basics.BL.Models;

public class User : Entities.User
{
    //private readonly BasicsDbContext _db;

    public User()
    {
    }

    /*public User(BasicsDbContext db)
    {
        _db = db;
    }*/

    public int CountAll()
    {
        using BasicsDbContext _db = new BasicsDbContext();
        return _db.User.Count();
    }

    public int Delete(Guid id)
    {
        using BasicsDbContext _db = new BasicsDbContext();
        
        var user = _db.User.Find(id);
        if (user != null)
        {
            _db.User.Remove(user);
            _db.SaveChanges();
            return 1;
        }
        return 0;
    }
}
