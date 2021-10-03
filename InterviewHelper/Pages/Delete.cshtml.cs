using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InterviewHelper.Model;
using InterviewHelper.ViewModels;

namespace InterviewHelper.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly InterviewHelper.Model.AuthDbContext _context;

        public DeleteModel(InterviewHelper.Model.AuthDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Interviewee Interviewee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Interviewee = await _context.Interviewee.FirstOrDefaultAsync(m => m.Id == id);

            if (Interviewee == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Interviewee = await _context.Interviewee.FindAsync(id);

            if (Interviewee != null)
            {
                _context.Interviewee.Remove(Interviewee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./ListInterviewees");
        }
    }
}
