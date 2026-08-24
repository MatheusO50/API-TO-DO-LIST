using To_Do_List.Models;
using To_Do_List.Interface;
using To_Do_List.DTO;
using Microsoft.EntityFrameworkCore;

namespace To_Do_List.Repository
{
    public class DbDataContext : DbContext
    {
        public DbDataContext(DbContextOptions<DbDataContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<TaskUser> Tasks { get; set; }

    }

    public class UserRepository : IRepository<User,UserDto>
    {
        private readonly DbDataContext _context;
        public UserRepository(DbDataContext context) {_context = context;}
        public UserDto AddItem(User item) 
        {
            _context.Users.Add(item);
            _context.SaveChanges();
            return new UserDto
            {
                Id = item.Id,
                Name = item.Name,
                Adress = item.Adress,
                Email = item.Email
            };
        }
        public UserDto GetItem(long id)
        {
            var user = _context.Users.Find(id);
            return new UserDto
            {
              Id = user.Id,
              Name = user.Name,
              Adress = user.Adress,
              Email = user.Email  
            };
        }
        public IEnumerable<UserDto> GetAll()
        {
            return _context.Users.Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Adress = x.Adress,
                Email = x.Email
            });
        }
        public void RemoveItem(long id)
        {
            var user = _context.Users.Find(id);
            try
            {
                _context.Users.Remove(user);
                _context.SaveChanges();    
            } catch(Exception ex) {Console.WriteLine(ex);}
        }
        public void UpdateItem(UserDto item)
        {
            var user = _context.Users.Find(item.Id);
            user.Id = item.Id;
            user.Name = item.Name;
            user.Adress = item.Adress;
            user.Email = item.Email;
            try{ _context.SaveChanges();}
            catch(Exception ex) {Console.WriteLine(ex);}
        }
    }
}