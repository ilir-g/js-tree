using IlirGashijstree.Data;
using IlirGashijstree.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IlirGashijstree.Controllers
{
    public class HomeController : Controller
    {

        private readonly Repository _db;
        public HomeController()
        {
            _db = new Repository();
        }
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public JsonResult GetTreeData()
        {
            var data = _db.GetCommodityChapters() as List<JsTreeModel>;
            var list = new List<JsTreeModel>();
            list.AddRange(data);
            foreach (var item in data)
            {
                list.AddRange(_db.GetCommodityRoots(int.Parse(item.id)));
            }
            var res = Json(list, JsonRequestBehavior.AllowGet);
            res.MaxJsonLength = int.MaxValue;
            return res;
          
        }
        [HttpGet]
        public JsonResult GetTreeDataChildren(int Id)
        {
           
             var data = _db.GetCommodityRoots(Id);
           
            return Json(data, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult Update_CommodityRoot(CommodityRoots model)
        {
           
            var result = _db.UpdateModel(model);
                if(result) {
                return Json("ok"); 
            }
            return Json("ko");
        } 
        [HttpPost]
        public JsonResult Delete_CommodityRoot(int Id)
        {
            var result = _db.DeleteCommodityRootById(Id);
            if (result)
            {
                return Json("ok");
            }
            return Json("ko");
        }
       
    }
}