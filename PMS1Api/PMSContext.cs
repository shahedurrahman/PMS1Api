using Microsoft.EntityFrameworkCore;
using PMS1Api.Models.EFModels;

namespace PMS1Api
{
    public class PMSContext : DbContext
    {
        public PMSContext(DbContextOptions<PMSContext> options) : base(options)
        {
        }

        public DbSet<Drug> Drug { get; set; }
    }
}
