using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using System.IO;
namespace MvcMovie.Models
{
    public class Video
    {

        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}
  
