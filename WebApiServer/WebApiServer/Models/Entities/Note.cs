﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServer.Models.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}