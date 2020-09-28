namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInformation")]
    public partial class UserInformation
    {
        public long Id { get; set; }

        [StringLength(200)]
        public string AccountName { get; set; }

        [StringLength(100)]
        public string DisplayName { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Designation { get; set; }

        [StringLength(200)]
        public string Department { get; set; }

        public bool? Active { get; set; }

        public DateTime? Modified { get; set; }

        public DateTime? Created { get; set; }
    }
}
