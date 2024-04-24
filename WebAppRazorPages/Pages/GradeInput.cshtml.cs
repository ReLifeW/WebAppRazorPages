using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using WebAppRazorPages.Model;
using WebAppRazorPages.Repository;

namespace WebAppRazorPages.Pages
{
    public class GradeInputModel : PageModel
    {
        private readonly AppDbContext _context; // Замените YourDbContext на ваш контекст базы данных
        public GradeInputModel(AppDbContext context)
        {
            _context = context;
        }

        //[BindProperty]
        //public GradeInputModel GradeInput { get; set; }

        public List<Subject> Subjects { get; set; }
        [BindProperty]
        public int SamoletId { get; set; }
        public Samolet Samolet { get; set; }

        [BindProperty] 
        public int SubjectId {  get; set; }
        [BindProperty] 
        public int Grade {  get; set; }
        [BindProperty] 
        public DateTime Date { get; set; }

        public IActionResult OnGet(int SamoletId)
        {
            Samolet = _context.Samolet.FirstOrDefault(x => x.Id == SamoletId);
            if (Samolet == null) { return NotFound(); }
            SamoletId = SamoletId;
            Subjects = _context.Subjects.ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Находим студента в базе данных
            var Samolet = _context.Samolet.FirstOrDefault(s => s.Id == SamoletId);
            if (Samolet == null)
            {
                return NotFound();
            }

            var subject = _context.Subjects.FirstOrDefault(s => s.Id == SubjectId);
            if (subject == null)
            {
                return NotFound();
            }
            // Создаем новую оценку
            var newGrade = new SubjectGrade
            {
                Subject = subject,
                Grade = Grade,
                Date = Date
            };

            Samolet.SubjectGrades.Add(newGrade);

            _context.SaveChanges();

            return RedirectToPage("/Samolet", new { SamoletId = SamoletId });
        }
    }
}
