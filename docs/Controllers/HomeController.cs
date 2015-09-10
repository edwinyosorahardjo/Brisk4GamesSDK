using docs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace docs.Controllers
{
    public static class GodOfDocumentation
    {
        private static Documentation docs = null;
        public static Documentation Get()
        {
            if (docs == null)
            {
                var xDoc = XDocument.Load(HttpContext.Current.Server.MapPath("~/bin/Brisk4GameSDK.xml"));
                var tmpDocs = new Documentation(xDoc);
                foreach (var item in tmpDocs.Members.Where(t=>t.Type == "T"))
                {
                    var related = tmpDocs.Members.Where(t => t.Type != "T" && t.Name.StartsWith(item.Name + "."));
                    item.Children = related.ToArray();
                }
                tmpDocs.Members = tmpDocs.Members.Where(t => t.Type == "T").OrderBy(t=>t.Name).ToArray();
                docs = tmpDocs;
            }

            return docs;
        }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(GodOfDocumentation.Get());
        }

        public ActionResult Type(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new HttpNotFoundResult();

            return View(GodOfDocumentation.Get().Members.First(m => m.Type == "T" && m.Name == name));
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