using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Housekeeping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Housekeeping.Pages.Main
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public IndexModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        [BindProperty]
        public User User { get; set; }
        public async Task OnGet(int id)
        {
            User = await db.User.FindAsync(id);
        }
    }
}
