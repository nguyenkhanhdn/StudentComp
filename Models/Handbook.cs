using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentComp.Models
{
    public class Handbook
    {
        public Handbook()
        {
            this.Comments = new HashSet<Comment>();
            this.Rates = new HashSet<Rate>();
        }
        public int Id { get; set; }
        [Display(Name="Tóm tắt")]
        [Required(ErrorMessage = "Không được để trống.")]
        public string Brief { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Không được để trống.")]
        public string Content { get; set; }
        [Display(Name = "Môn học")]
        [Required(ErrorMessage = "Không được để trống.")]
        public string Type { get; set; }
        [Display(Name = "Lượt xem")]
        public Nullable<int> Hit { get; set; }
        [Display(Name = "Bình luận")]
        public virtual ICollection<Comment> Comments { get; set; }
        [Display(Name = "Đánh giá")]
        public virtual ICollection<Rate> Rates { get; set; }
    }
}