using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BackstageWeb.Models;

namespace BackstageWeb.Controllers
{
    public class BaseController : Controller
    {
       
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Session["LoginUser"]==null)
            {
                Response.Redirect("/Login/LoginPage");
            }
            else
            {
                CompanyContext db = new CompanyContext();
                StringBuilder menustr = new StringBuilder();

                db_Users loginer = (db_Users)Session["LoginUser"];
                List<db_Menu> menulist = (from d in db.db_Menu where d.UserNo == loginer.UserNo where d.IsNo == false where d.MenuNo=="" orderby d.Id ascending select d).ToList();
                foreach (var item in menulist)
                {
                    if (item.MenuNo==null||item.MenuNo.Trim()=="")
                    {
                        
                        if (item.URL.Trim() == "javascript:;")
                        {
                            menustr.AppendFormat("<li class='layui-nav-item'><a href='javascript:;'>" + item.MenuName + "</a>");
                            List<db_Menu> childmenu = (from d in db.db_Menu where d.MenuNo.Trim() == item.Id.ToString() where d.IsNo == false select d).ToList();
                            menustr.AppendFormat("<dl class='layui-nav-child'>");
                            foreach (var child in childmenu)
                            {
                                menustr.AppendFormat("<dd><a href='" + child.URL + "'>" + child.MenuName + "</a></dd>");
                            }
                            menustr.AppendFormat("</dl></li>");
                        }
                        else
                        {
                            menustr.AppendFormat("<li class='layui-nav-item'><a href='" + item.URL + "'>" + item.MenuName + "</a></li>");
                        }
                    }
                }
                ViewBag.Menu = menustr;
                ViewBag.LoginName ="欢迎"+ (loginer.UserNo.Trim() == "1" ? "超级管理员-" + loginer.UserName : "管理员-" + loginer.UserName);
            }
        }
    }
}