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


            List<Email> emailList = new List<Email>();

            for (int i = 1; i <= 50; i++)
            {
                var item = new Email()
                {
                    From = string.Concat("email_from_", i.ToString(), "@mail.com"),
                    Mail = string.Concat(i.ToString(), "mail text"),
                    Title = string.Concat("mail title", i.ToString()),
                    To = string.Concat("email_to_", i.ToString(), "@mail.com")
                };

                emailList.Add(item);
            }

            db.Emails.AddRange(emailList);



            List<MyTask> tasksList = new List<MyTask>();

            for (int i = 1; i <= 50; i++)
            {
                var item = new MyTask()
                {
                    Details = string.Concat("Details ", i.ToString()),
                    Ends = string.Concat("Ends", i.ToString()),
                    Status = string.Concat("Status", i.ToString()),
                };

                tasksList.Add(item);
            }

            db.Tasks.AddRange(tasksList);


            List<Note> notesList = new List<Note>();

            for (int i = 1; i <= 50; i++)
            {
                var item = new Note()
                {
                    Content = string.Concat("Content ", i.ToString())
                };

                notesList.Add(item);
            }

            db.Notes.AddRange(notesList);

            db.SaveChanges();
        }
    }
}