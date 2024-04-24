using System.ComponentModel.DataAnnotations;

namespace WebAppRazorPages.Model
{
    public class Samolet
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        public string Type { get; set; }
        public string Model { get; set; }
        public object SubjectGrades { get; internal set; }

        public Samolet()
        {
            Name ??= string.Empty;
            Type ??= string.Empty;
            Model ??= string.Empty;
        }
    }
}
