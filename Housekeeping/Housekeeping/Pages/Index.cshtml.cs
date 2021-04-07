using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Housekeeping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Housekeeping.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public IndexModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
        }

        [BindProperty]
        public User User { get; set; }
        public async Task<IActionResult> OnPost()
        {
            var user = await db.User.FirstOrDefaultAsync(u => u.UserName == User.UserName && u.Password == User.Password);

            //If the username and password are not correct
            if (user == null)
            {
                //Since I'm not smart or know how to dynamically pop up the label, I just made a new page
                return RedirectToPage("FailedLogin");
            }

            if(user.Role.Equals("HouseKeeper"))
            {
                return RedirectToPage($"/Housekeeper/Index", new { id = user.Id });
            }
            if(user.Role.Equals("FrontDesk"))
            {
                return RedirectToPage($"/Main/Index", new { id = user.Id });
            }

            return null;

        }
    }
}
