using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Repository;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    public class SamoletModel : PageModel
    {
        public SamoletModel(ISamoletRepository SamoletRepository)
        {
            _SamoletRepository = SamoletRepository;
        }
        private ISamoletRepository _SamoletRepository;
        public Samolet? Samolet { get; set; }
        public IActionResult OnGet(int id = 1) 
        {
            Samolet = _SamoletRepository.GetUserById(id); // запрашиваем у контроллера пользователся и id из параметра
            if (Samolet == null) return NotFound(); // если пользватель не нашелся выкидываем ошибку HTTP 404
            return Page(); // выводим страницу пользователя
        }
    }
}
