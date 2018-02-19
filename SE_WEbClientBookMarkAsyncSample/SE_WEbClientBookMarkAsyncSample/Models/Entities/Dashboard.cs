using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_WEbClientBookMarkAsyncSample.Models.Entities
{

    public class Dashboard
    {
        public List<Bookmark> Bookmarks { get; set; }
        public List<Email> Emails { get; set; }
        public List<MyTask> Tasks { get; set; }
        public List<Note> Notes { get; set; }

        public long TimeTaken { get; set; }
    }
}