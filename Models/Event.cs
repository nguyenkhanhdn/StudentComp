using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentComp.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        
        public string Subject { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public System.DateTime Start { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
    }
}