namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommentDetail")]
    public partial class CommentDetail
    {
        public long Id { get; set; }

        public long PostDetail_Id { get; set; }

        public string Comment { get; set; }

        public long LikeCount { get; set; }

        public long? DislikeCount { get; set; }

        public long? Author { get; set; }
        public long? Editor { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool Active { get; set; }

        public virtual PostDetail PostDetail { get; set; }
    }
}
