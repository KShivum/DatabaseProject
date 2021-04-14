using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Housekeeping.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Housekeeping.Pages.Main
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public IndexModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        [TempData]
        public int userId { get; set; }
        public User LoginUser { get; set; }
        public List<Room> Rooms {get; set;}
        public List<User> Housekeepers { get; set; }
        [BindProperty]
        public Room CurrentRoom { get; set; }
        public async Task OnGet(int id)
        {
            
            LoginUser = await db.User.FindAsync(id);
            userId = id;
            HttpContext.Session.SetInt32("UserId", id);
            Rooms = await db.Room.ToListAsync();
            Housekeepers = await db.User.Where(u => u.Role.Equals("HouseKeeper")).ToListAsync();
        }

        public async Task<IActionResult> OnPostChangeStatus(int roomNo, string status, int? assignedEmployee, User user)
        {
            //var emp = assignedEmployee;
            string emp = Request.Form[$"{roomNo} select"];
            int? empId;
            if(String.IsNullOrEmpty(emp))
            {
                empId = null;
            }
            else
            {
                empId = Convert.ToInt32(emp);
            }
            var roomPrev = await db.Room.FindAsync(roomNo);
            var roomNew = roomPrev;
            roomNew.Status = status;
            roomNew.AssignedEmployee = empId;
            var log = new Log();
            var tempUserId = (int)HttpContext.Session.GetInt32("UserId");

            log.RoomNo = roomNo;
            log.Assignee = tempUserId;
            log.AssignedEmployee = empId;
            log.StatusChangedFrom = roomPrev.Status;
            log.StatusChangedTo = status;
            log.Date = DateTime.Now;

            db.Room.Update(roomNew);
            db.Log.Add(log);
            await db.SaveChangesAsync();
            return RedirectToPage($"/Main/Index", new { id = tempUserId });


        }


    }
}
