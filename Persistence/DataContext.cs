using Microsoft.EntityFrameworkCore;
using Domain;
namespace Persistence
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        // create a table called Activities which contains property inside Activity
        public DbSet<Activity> Activities {get; set;}
    }
}