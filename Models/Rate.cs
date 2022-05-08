using System;

namespace StudentComp.Models
{
    public class Rate
    {
        public int Id { get; set; }
        public Nullable<int> HandbookId { get; set; }
        public Nullable<decimal> Rate1 { get; set; }
        public virtual Handbook Handbook { get; set; }
    }
}