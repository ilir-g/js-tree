using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IlirGashijstree.Models
{
    public partial class CommodityRoots
    {
        [Key]
        public int Id { get; set; }
        public int CommodityChapterId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
       
        
    }

   
}