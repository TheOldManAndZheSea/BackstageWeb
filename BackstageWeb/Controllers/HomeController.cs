using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackstageWeb.Models;

namespace BackstageWeb.Controllers
{
    /// <summary>
    /// 后台控制器
    /// </summary>
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }   
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult PersonData()
        {
            db_Users loginer = (db_Users)Session["LoginUser"];
            ViewBag.PersonData = loginer;
            return View();
        }
        /// <summary>
        /// 商品管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductManager()
        {
            return View();
        }
        CompanyContext db = new CompanyContext();
        /// <summary>
        /// 得到商品的分页数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetProductPages()
        {
            int page = Convert.ToInt32(Request.Params["page"]);
            int limit = Convert.ToInt32(Request.Params["limit"]);
            //分页数据
            var pagelist = (from d in db.db_Product join p in db.db_ProductType on d.Type equals p.Id where d.IsNo == false orderby d.Id select new {Name= d.Name,Count=d.Count, UnitPrice=d.UnitPrice,TypeName=p.Name,Image=d.Image}).Skip(limit * (page - 1)).Take(limit).ToList();
            //总数据类库
            List<db_Product> productlist = (from d in db.db_Product where d.IsNo == false orderby d.Id select d).ToList();
            LayUIJson json = new LayUIJson();
            json.code = 0;
            json.count = productlist.Count;
            json.data = pagelist;
            json.msg = "";
            return Json(json,JsonRequestBehavior.AllowGet);
        }
    }
}