namespace eHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Blog_Comment
    {
        [Key]
        public int COMMENT_ID { get; set; }

        public int BLOG_FID { get; set; }

        public DateTime BLOG_DATE { get; set; }

        [Required]
        [StringLength(50)]
        public string COMMENT_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string COMMENT_EMAIL { get; set; }

        [Required]
        [StringLength(250)]
        public string COMMENT_MESSAGE { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
