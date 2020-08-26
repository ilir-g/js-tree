using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IlirGashijstree.Models
{
    public partial class JsTreeModel
    {
        public string id { get; set; }
        public string parent { get; set; }

        public string text { get; set; }
        public string ChapterCode { get; set; }
        public string ChapterName { get; set; }
        public string RootCode { get; set; }
        public string RootName { get; set; }

        public int ChapterId { get; set; }
        public int RootId { get; set; }
    }
}