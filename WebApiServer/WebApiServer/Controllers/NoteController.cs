using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiServer.Abstract;
using WebApiServer.Models.Entities;
using WebApiServer.Repositories;

namespace WebApiServer.Controllers
{
    public class NoteController : ApiController
    {
        private BaseRepository<Note> repo;

        public NoteController()
        {
            repo = new NoteRepository();
        }

        [HttpGet]
        public async Task<IEnumerable<Note>> GeNotes()
        {
            await Task.Delay(500);
            return await repo.GetListAsync();
        }


        [HttpGet]
        [Route("api/note/getsync")]
        public IEnumerable<Note> GetSync()
        {
            Thread.Sleep(500);

            var res = repo.GetList();
            return res;
        }
    }
}

