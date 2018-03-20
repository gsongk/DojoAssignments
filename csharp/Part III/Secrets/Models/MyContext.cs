using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Secrets.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        { }
        public DbSet<User> users { get; set; }
        // public DbSet<Secret> secrets { get; set; }
        // public DbSet<Like> likes { get; set; }

    }
}