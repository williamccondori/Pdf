using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Pdf.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase archivo)
        {

            BinaryReader theReader = new BinaryReader(archivo.InputStream);
            byte[] thePictureAsBytes = theReader.ReadBytes(archivo.ContentLength);

            string base64 = Convert.ToBase64String(thePictureAsBytes);

            TempData["Archivo"] = base64;

            return RedirectToAction("About");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}