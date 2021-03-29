using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Housekeeping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
namespace Housekeeping.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public User user { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            using (MySqlConnection con = new MySqlConnection(Configuration.GetConnectionString("Default")))
            MySqlDataReaderreader = new MySql


            return null;
        }
    }
}
