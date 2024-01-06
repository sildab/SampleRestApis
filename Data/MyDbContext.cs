using Microsoft.EntityFrameworkCore;
using SampleRestApis.Data.Entities;

namespace SampleRestApis.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {


        }
        public DbSet<Todo> Todo { get; set; }
    }
}
