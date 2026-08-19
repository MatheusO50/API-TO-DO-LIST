using To_Do_List.Models;
using To_Do_List.Interface;
using Microsoft.EntityFrameworkCore;

namespace To_Do_List.Repository
{
    public class DbDataContext : DbContext
    {
        public DbDataContext(DbContextOptions<DbDataContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<TaskUser> Tasks { get; set; }

    }

    public class UserRepository : IRepository
    {
        
    }
}