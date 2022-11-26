using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataContext
{
    public class PublishDbContext:DbContext
    {


        public PublishDbContext(DbContextOptions<PublishDbContext> options) : base(options) { }

        public DbSet<User> Users{ get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Publish> Publishs { get; set; }
    }
}
