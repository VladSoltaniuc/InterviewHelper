using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewHelper.Model;
using InterviewHelper.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InterviewHelper.Pages
{
    public class IntervieweesModel : PageModel
    {
        private readonly AuthDbContext _db;
        public IEnumerable<Interviewee> objList;

        public IntervieweesModel(AuthDbContext db)
        {
            _db = db;
            objList = _db.Interviewee;
        }

        public void OnGet()
        {
        }
    }
}
