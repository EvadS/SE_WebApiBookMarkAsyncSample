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
    public class TaskController : ApiController
    {
        private BaseRepository<MyTask> repository;

        public TaskController()
        {
            repository = new TaskRepository();
        }

        [HttpGet]
        public IEnumerable<MyTask> GetTasks()
        {
            var res = repository.GetList();
            return res;
        }
    }
}
