using To_Do_List.Models;
using Microsoft.EntityFrameworkCore;

namespace To_Do_List.Repository
{
    public class DbDataContext : DbContext
    {
        public DbDataContext(DbContextOptions<DbDataContext> options) : base(options) {}
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }

    }
}