using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InterviewHelper.Model;
using InterviewHelper.ViewModels;

namespace InterviewHelper.Pages
{
    public class EditModel : PageModel
    {
        private readonly InterviewHelper.Model.AuthDbContext _context;

        public EditModel(InterviewHelper.Model.AuthDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Interviewee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntervieweeExists(Interviewee.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ListInterviewees");
        }

        private bool IntervieweeExists(int id)
        {
            return _context.Interviewee.Any(e => e.Id == id);
        }
    }
}
