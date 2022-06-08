﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.IO;
using u21653268_HW03.Models;

namespace u21653268_HW03.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Videos()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Videos/"));
            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
        }

        public FileResult DownloadVideo(string fileName)
        {
            string path = Server.MapPath("~/Media/Videos/") + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteVideo(string fileName)
        {
            string path = Server.MapPath("~/Media/Videos/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            System.IO.File.Delete(path);
            return RedirectToAction("Videos");
        }
    }
}