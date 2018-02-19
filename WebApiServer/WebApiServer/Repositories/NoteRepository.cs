using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiServer.Abstract;
using WebApiServer.Models;
using WebApiServer.Models.Entities;

namespace WebApiServer.Repositories
{
    public class NoteRepository : BaseRepository<Note>
    {
        private MarkTaskContext db;
        private bool disposed = false;

        public NoteRepository()
        {
            db = new MarkTaskContext();
        }

        public void Create(Note item)
        {
            db.Notes.Add(item);
        }       

        public void Delete(int id)
        {
            Note item = db.Notes.Find(id);
            if (item != null)
                db.Notes.Remove(item);
        }

        public Note GetItem(int id)
        {
            return db.Notes.Find(id);
        }

        public IEnumerable<Note> GetList()
        {
            return db.Notes.ToList();
        }



        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Note item)
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

        public async Task<IEnumerable<Note>> GetListAsync()
        {
            return await db.Notes.ToListAsync();
        }

        //private async Task<Note> privateMethod1Async()
        //{
        //    return await db.Notes.FirstOrDefaultAsync();
        //}

    }
}