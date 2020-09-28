namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostDetail")]
    public partial class PostDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PostDetail()
        {
            CommentDetails = new HashSet<CommentDetail>();
        }

        public long Id { get; set; }

        public long? TotalComment { get; set; }

        public string Post { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public long Author { get; set; }

        public long Editor { get; set; }

        public bool? Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentDetail> CommentDetails { get; set; }
    }
}
