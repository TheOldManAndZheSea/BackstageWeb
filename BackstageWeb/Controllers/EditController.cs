using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackstageWeb.Models;

namespace BackstageWeb.Controllers
{
    public class EditController : BaseController
    {
        // GET: Edit
        public ActionResult Index()
        {
            return View();
        }
        CompanyContext db = new CompanyContext();
        [HttpPost]
        public ActionResult EditPwd(int loginid, string password)
        {
            var user = (from d in db.db_Users where d.Id == loginid select d).Single();
            user.PassWord = password;
            int result = db.SaveChanges();
            if (db.SaveChanges()==0)
            {
                return Json("1",JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("2", JsonRequestBehavior.AllowGet);
            }
        }
    }
}