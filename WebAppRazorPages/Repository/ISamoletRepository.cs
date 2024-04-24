using WebAppRazorPages.Model;

namespace WebAppRazorPages.Repository
{
    public interface ISamoletRepository
    {
        public Samolet? GetUserById(int id); // Получить пользователя по идентификатору
        public List<Samolet> GetUsers(); // Получить список всех пользователей
        public Samolet UpdateUser(Samolet upUser); // Обновить информацию о пользователе
        public Samolet DeleteUser(int id);
    }
}
