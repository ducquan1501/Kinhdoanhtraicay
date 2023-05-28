using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kinhdoanhtraicay.Models

{
    public class KDTCDbContext : DbContext
    {
        public KDTCDbContext(DbContextOptions<KDTCDbContext> options) :base(options)
        {
            
        }           
    }
}
