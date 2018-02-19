using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServer.Models.Entities
{
    public class Bookmark
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
    }
}