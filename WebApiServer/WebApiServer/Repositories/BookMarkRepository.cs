using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiServer.Abstract;
using WebApiServer.Models;
using WebApiServer.Models.Entities;

namespace WebApiServer.Repositories
{
    public class BookMarkRepository : BaseRepository<Bookmark>
    {
        private MarkTaskContext db;
        private bool disposed = false;

        public BookMarkRepository()
        {
            db = new MarkTaskContext();
        }

        public void Create(Bookmark item)
        {
            db.Bookmarks.Add(item);
        }

        public void Delete(int id)
        {
            Bookmark book = db.Bookmarks.Find(id);
            if (book != null)
                db.Bookmarks.Remove(book);
        }

        public Bookmark GetItem(int id)
        {
            return db.Bookmarks.Find(id);
        }

        public IEnumerable<Bookmark> GetList()
        {
            return db.Bookmarks.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Bookmark item)
        {
            db.Entry(item).State = EntityState.Modified;
        }



        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}