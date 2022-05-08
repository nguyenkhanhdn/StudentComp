using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentComp.Models
{
    public class Maxim
    {
        public int Id { get; set; }
        [Display(Name = "Thành ngữ")]
        [Required(ErrorMessage="Không được rỗng")]
        public string Maxim1 { get; set; }
        [Display(Name = "Tác giả")]
        [Required(ErrorMessage = "Không được rỗng")]
        public string Author { get; set; }
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }
        [Display(Name = "Ngày đăng")]
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}