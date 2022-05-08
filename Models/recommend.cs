using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentComp.Models
{
    public class Recommend
    {
        public int Id { get; set; }
        public int HandbookId { get; set; }
        public string Title { get; set; }
        public string RecommendArticle { get; set; }
        public int Hit { get; set; }
        public DateTime CreatedDate { get; set; }
             
    }
}