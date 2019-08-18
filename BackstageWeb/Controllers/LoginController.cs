using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackstageWeb.Models;

namespace BackstageWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }
        CompanyContext db=new CompanyContext();
        [HttpPost]
        public ActionResult LoginResult(string username,string password)
        {
            db_Users users = (from d in db.db_Users where d.AccoutNum == username select d).FirstOrDefault();
            string result = "";
            if (users==null)
            {
                result = "该用户不存在！";
            }
            else
            {
                if (users.PassWord == password)
                {
                    result = "1";
                    Session["LoginUser"] = users;
                }
                else
                {
                    result = "您输入的密码不正确！";
                }
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public ActionResult OutLogin()
        {
            Session["LoginUser"] = null;
            return RedirectToAction("LoginPage");
        }
    }
}