using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackstageWeb.Controllers
{
    /// <summary>
    /// 前端控制器
    /// </summary>
    public class FrontController : Controller
    {
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 消息
        /// </summary>
        /// <returns></returns>
        public ActionResult Message()
        {
            return View();
        }
        /// <summary>
        /// 关于
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View();
        }
    }
}