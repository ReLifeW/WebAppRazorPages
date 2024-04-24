using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Repository;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    [Authorize]
    public class EditSamoletModel : PageModel
    {

        public EditSamoletModel(ISamoletRepository SamoletRepository)
        {
            _SamoletRepository = SamoletRepository;
        }

        private ISamoletRepository _SamoletRepository;
        public Samolet? Samolet { get; set; }
        public IActionResult OnGet(int id)
        {
            Samolet = _SamoletRepository.GetUserById(id);
            Samolet ??= new();
            return Page();
        }

        public IActionResult OnPost(Samolet? SamoletForm)
        {
            
            var userDB = _SamoletRepository.UpdateUser(SamoletForm);
            if (userDB == null) return NotFound();
            return RedirectToPage("Samolets");
        }
    }
}