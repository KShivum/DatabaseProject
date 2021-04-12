using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housekeeping.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }
        public DbSet<User> User { get; set; }

        public DbSet<Room> Room { get; set; }
        public DbSet<Log> Log { get; set; }

    }

}
