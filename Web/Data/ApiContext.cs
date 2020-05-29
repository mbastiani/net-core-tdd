using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
          : base(options)
        {}
        public DbSet<PersonModel> Persons { get; set; }
    }
}