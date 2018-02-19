using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServer.Models.Entities
{
    public class MyTask
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Ends { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}