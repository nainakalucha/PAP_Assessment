using Assignment.DAL;
using Assignment.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Assignment.Tests
{
    /// <summary>
    /// DB context initiator.
    /// </summary>
    public class BaseDBContextInitiator : MapperInitiator
    {
        public SqlDbContext DBContext { get; }
        public BaseDBContextInitiator()
        {
            var builder = new DbContextOptionsBuilder<SqlDbContext>()
            .UseInMemoryDatabase(databaseName: "ChatDb");

            var context = new SqlDbContext(builder.Options);
            var users = Enumerable.Range(1, 10)
                .Select(i => new UserLogin { UserName = "User1", UserPass = "12345"});
            context.UserLogin.AddRange(users);
            int changed = context.SaveChanges();
            DBContext = context;
        }
    }
}
