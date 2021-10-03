using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InterviewHelper.Model;
using InterviewHelper.ViewModels;

namespace InterviewHelper.Pages
{
    public class CreateModel : PageModel
    {
        private readonly InterviewHelper.Model.AuthDbContext _context;

        public CreateModel(InterviewHelper.Model.AuthDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Interviewee Interviewee { get; set; }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Interviewee.Add(Interviewee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ListInterviewees");
        }
    }
}
