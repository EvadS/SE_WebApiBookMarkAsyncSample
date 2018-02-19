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
    public class TaskRepository : BaseRepository<MyTask>
    {
        private MarkTaskContext db;
        private bool disposed = false;

        public TaskRepository()
        {
            db = new MarkTaskContext();      
        }

        public void Create(MyTask item)
        {
            db.Tasks.Add(item);
        }

        public void Delete(int id)
        {
            MyTask item = db.Tasks.Find(id);
            if (item != null)
                db.Tasks.Remove(item);
        }

        public MyTask GetItem(int id)
        {
            return db.Tasks.Find(id);
        }

        public IEnumerable<MyTask> GetList()
        {
            return db.Tasks.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(MyTask item)
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