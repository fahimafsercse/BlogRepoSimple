namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminUser")]
    public partial class AdminUser
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountName { get; set; }

        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }

        public long UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public bool? Active { get; set; }

        public DateTime Created { get; set; }

        public long Author { get; set; }

        public long Editor { get; set; }

        public DateTime Modified { get; set; }
    }
}
