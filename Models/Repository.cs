using IlirGashijstree.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using System.Data;
using EntityState = System.Data.Entity.EntityState;

namespace IlirGashijstree.Models
{
    public class Repository
    {
       
        private readonly Context _db;
        public Repository()
        {
            _db = new Context();
        }

        public List<JsTreeModel> GetCommodityChapters()
        {
            var entities = (from chapters in _db.CommodityChapters
                            select new JsTreeModel
                            {
                                id = chapters.Id.ToString(),
                                parent = "#",
                                text = "(" + chapters.Code + ") " + chapters.Name,
                                ChapterId = chapters.Id,
                                ChapterCode = chapters.Code,
                                ChapterName = chapters.Name
                            }).ToList();
            return entities;
        }
        public List<JsTreeModel> GetCommodityRoots(int ChapterId)
        {

            var entities = (from roots in _db.CommodityRoots
                            where roots.CommodityChapterId == ChapterId
                            select new JsTreeModel
                            {
                                id = (roots.Id + 100).ToString(),
                                parent = ChapterId.ToString(),
                                text = "(" + roots.Code + ") " + roots.Name,
                                RootCode = roots.Code,
                                RootName = roots.Name,
                                RootId = roots.Id
                            }).ToList();


            return entities;
        }       


        public bool DeleteCommodityRootById(int Id)
        {
            try
            {

                var entity = (from root in _db.CommodityRoots
                              where root.Id == Id
                              select root).SingleOrDefault();

                _db.Entry(entity).State = EntityState.Deleted;
                _db.CommodityRoots.Remove(entity);
                _db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

     
        public bool UpdateModel(CommodityRoots model)
        {
            try
            {
                _db.CommodityRoots.Attach(model);
                _db.Entry(model).Property(x => x.Name).IsModified = true;
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
      
    }

  
}