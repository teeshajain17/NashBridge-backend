using Microsoft.EntityFrameworkCore;
using NashBridge.Model;
using System.Net.Sockets;

namespace NashBridge.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Slot> Slots { get; set; }


    }
}
