using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentComp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Display(Name = "Bài viết")]
        [Required(ErrorMessage = "Không được rỗng.")]
        public Nullable<int> HandbookId { get; set; }
        [Display(Name = "Thành viên")]
        [Required(ErrorMessage = "Không được rỗng.")]
        public string UserName { get; set; }
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Không được rỗng.")]
        public string Comment1 { get; set; }
        [Display(Name = "Ngày bình luân")]
        public Nullable<System.DateTime> CommentDate { get; set; }

        public virtual Handbook Handbook { get; set; }
    }
}