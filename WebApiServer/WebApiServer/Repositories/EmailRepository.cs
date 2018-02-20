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
    public class EmailRepository : BaseRepository<Email>
    {
        private MarkTaskContext db;
        private bool disposed = false;

        public EmailRepository()
        {
            db = new MarkTaskContext();
        }

        public void Create(Email item)
        {
            db.Emails.Add(item);
        }

        public void Delete(int id)
        {
            Email item = db.Emails.Find(id);
            if (item != null)
                db.Emails.Remove(item);
        }     

        public Email GetItem(int id)
        {
            return db.Emails.Find(id);
        }

        public IEnumerable<Email> GetList()
        {
            return db.Emails.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Email item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Email>> GetListAsync()
        {
            return await db.Emails.ToListAsync();
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