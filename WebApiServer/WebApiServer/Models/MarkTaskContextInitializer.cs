using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiServer.Models.Entities;

namespace WebApiServer.Models
{
    public class MarkTaskContextInitializer : CreateDatabaseIfNotExists<MarkTaskContext>
    {
        protected override void Seed(MarkTaskContext db)
        {
            List<Bookmark> bookMarksList = new List<Bookmark>()
            {
                new Bookmark() { Title = DateTime.Now.ToString(), Url = "/" + DateTime.Now.ToString()+"/"},
                new Bookmark() { Title = DateTime.Now.ToString(), Url = "/" + DateTime.Now.ToString()+"/"},
                new Bookmark() { Title = DateTime.Now.ToString(), Url = "/" + DateTime.Now.ToString()+"/"},
                new Bookmark() { Title = DateTime.Now.ToString(), Url = "/" + DateTime.Now.ToString()+"/"},

            };

            db.Bookmarks.AddRange(bookMarksList);
            db.SaveChanges();
        }
    }
}