using Microsoft.EntityFrameworkCore;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Repository
{
    public class SqlSamoletRepository : ISamoletRepository
    {
        private readonly AppDbContext _appDbContext;

        public SqlSamoletRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Samolet DeleteUser(int id)
        {
            var user = GetUserById(id);
            _appDbContext.Remove(user);
            _appDbContext.SaveChanges();
            return user;
        }

        public Samolet? GetUserById(int id)
        {
            return _appDbContext.Samolet.Where( u => u.Id == id).Include(s => s.SubjectGrades).ThenInclude( s => s.Subject ).ToList().FirstOrDefault();
        }

        public List<Samolet> GetUsers()
        {
            return _appDbContext.Samolet.ToList();
        }

        public Samolet UpdateUser(Samolet upUser)
        {
            if (upUser.Id == 0)
            {
                _appDbContext.Samolet.Add(upUser);
            }
            else
            {
                _appDbContext.Samolet.Update(upUser);
            }
            _appDbContext.SaveChanges();
            return upUser;
        }
    }
}
