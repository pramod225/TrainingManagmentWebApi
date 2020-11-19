using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TrainingManagmentWebApi.Models
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Batch> batches { get; set; }
        public DbSet<Course> courses { get; set; }
        public UserDbContext()
        {
            Database.SetInitializer<UserDbContext>(new DropCreateDatabaseIfModelChanges<UserDbContext>());
        }
    }
}