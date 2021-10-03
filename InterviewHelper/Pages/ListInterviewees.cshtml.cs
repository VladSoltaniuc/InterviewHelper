using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InterviewHelper.Model;
using InterviewHelper.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace InterviewHelper.Pages
{
    [Authorize]
    public class ListIntervieweesModel : PageModel
    {
        private readonly InterviewHelper.Model.AuthDbContext _context;

        public ListIntervieweesModel(InterviewHelper.Model.AuthDbContext context)
        {
            _context = context;
        }

        public IList<Interviewee> Interviewee { get;set; }

        public async Task OnGetAsync()
        {
            Interviewee = await _context.Interviewee.ToListAsync();
        }
    }
}
