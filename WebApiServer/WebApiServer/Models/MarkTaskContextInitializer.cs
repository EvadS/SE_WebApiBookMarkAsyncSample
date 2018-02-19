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
            List<Bookmark> bookMarksList = new List<Bookmark>();
           
            for (int i = 0; i < 50; i++)
            {
                var item = new Bookmark() { Title = DateTime.Now.ToString(), Url = "/" + DateTime.Now.ToString() + "/" };
                bookMarksList.Add(item);
            }

            db.Bookmarks.AddRange(bookMarksList);
            db.SaveChanges();
        }
    }
}