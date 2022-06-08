using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21653268_HW03.Models
{
    public class FileModel
    {
        public String FileName { get; set; }

        public HttpPostedFileBase Files { get; set; }

    }
}