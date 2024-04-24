using WebAppRazorPages.Model;

namespace WebAppRazorPages.Repository
{
    public class MocSamoletRepository : ISamoletRepository
    {
        private List<Samolet> _Samolets;
        public MocSamoletRepository() 
        {
            _Samolets ??= new List<Samolet>();
            /*
            List<SubjectGrade> subjectGrade = new() 
            { 
                new SubjectGrade { Name = "Математика", Grade = 5 },
                new SubjectGrade { Name = "Информатика", Grade = 4 },
                new SubjectGrade { Name = "Программирование", Grade = 2 },
                new SubjectGrade { Name = "Английский", Grade = 3 },
            };
            _Samolets.Add(new() { Id = 1, Name = "Первый", Name = "first@first.ru" , SubjectGrades = subjectGrade });
            _Samolets.Add(new() { Id = 2, Name = "Второй", Name = "first@first.ru" });
            _Samolets.Add(new() { Id = 3, Name = "Третий", Name = "first@first.ru" });
            */
        }

        public Samolet DeleteUser(int id)
        {
            var user = GetUserById(id);
            _Samolets.Remove(user);
            return user;
        }

        public Samolet? GetUserById(int id) 
        {
            return _Samolets.Where(u => u.Id == id).ToList().FirstOrDefault();            
        }

        public List<Samolet> GetUsers() 
        {
            return _Samolets;
        }

        public Samolet UpdateUser(Samolet upUser) 
        {
            var userDB = GetUserById(upUser.Id);
            if (userDB != null)
            {
                _Samolets.Remove(userDB);
            }
            _Samolets.Add(upUser);
            return upUser;
        }
    }
}
