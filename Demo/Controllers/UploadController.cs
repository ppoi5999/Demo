﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Upload()
        {
            return View();
        }
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/images/profile"), pic);
                    // file is uploaded
                    file.SaveAs(path);

                    // save the image path path to the database or you can send image 
                    // directly to database
                    // in-case if you want to store byte[] ie. for DB
                    /* using (MemoryStream ms = new MemoryStream())
                     {
                         file.InputStream.CopyTo(ms);
                         byte[] array = ms.GetBuffer();
                     }*/

                }
                // after successfully uploading redirect the user
                return RedirectToAction("Upload", "Upload");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
           
        }
    }
}