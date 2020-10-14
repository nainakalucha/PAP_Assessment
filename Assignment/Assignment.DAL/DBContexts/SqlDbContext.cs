using Assignment.Common;
using Assignment.Model;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DAL
{
    /// <summary>
    /// Db context.
    /// </summary>
    public class SqlDbContext : DbContext
    {
        /// <summary>
        /// Create new instance of <see cref="SqlDbContext"/> class.
        /// </summary>
        /// <param name="options">Db context options.</param>
        public SqlDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<UserLogin> UserLogin { get; set; }
    }
}
