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
    public class TaskController : ApiController
    {
        private BaseRepository<MyTask> repo;

        public TaskController()
        {
            repo = new TaskRepository();
        }

        [HttpGet]
        public async Task<IEnumerable<MyTask>> GeNotes()
        {
            await Task.Delay(500);
            return await repo.GetListAsync();
        }

        [HttpGet]
        [Route("api/task/getsync")]
        public IEnumerable<MyTask> GetSync()
        {
            Thread.Sleep(500);

            var res = repo.GetList();
            return res;
        }
    }
}
