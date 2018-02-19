using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiServer.Abstract;
using WebApiServer.Models.Entities;
using WebApiServer.Repositories;

namespace WebApiServer.Controllers
{
    public class NoteController : ApiController
    {
        private BaseRepository<Note> repository;

        public NoteController()
        {
            repository = new NoteRepository();
        }

        [HttpGet]
        public IEnumerable<Note> GeNotes()
        {
            var res = repository.GetList();
            return res;
        }
    }
}
