using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewHelper.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InterviewHelper.Pages
{
    //[Authorize]
    public class CreateIntervieweesModel : PageModel
    {
        [BindProperty]
        public Interviewee Interviewee { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid == false)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
