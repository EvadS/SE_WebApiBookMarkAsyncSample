using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiServer.Models.Entities;

namespace WebApiServer.Models
{
    public class MarkTaskContext : DbContext
    {
        static MarkTaskContext()
        {
            Database.SetInitializer(new MarkTaskContextInitializer());
        }

        public MarkTaskContext() : base("DbConnection")
        {

        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<MyTask> Tasks { get; set; }

        public DbSet<Bookmark> Bookmarks { get; set; }
    }
}