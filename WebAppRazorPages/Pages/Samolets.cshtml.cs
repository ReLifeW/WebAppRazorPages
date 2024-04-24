using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Model;
using WebAppRazorPages.Repository;

namespace WebAppRazorPages.Pages
{
    public class SamoletsModel : PageModel
    {
        public SamoletsModel(ISamoletRepository SamoletRepository) 
        {
            _SamoletRepository = SamoletRepository;
        }
        private ISamoletRepository _SamoletRepository;
        public List<Samolet> Samolets { get; set; }
        public IActionResult OnGet()
        {
            Samolets = _SamoletRepository.GetUsers();
            return Page();
        }
        public IActionResult OnPost()
        {
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            _SamoletRepository.DeleteUser(id);
            return RedirectToPage();
        }

    }
}
