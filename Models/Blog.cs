namespace eHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Blog")]
    public partial class Blog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Blog()
        {
            Blog_Comment = new HashSet<Blog_Comment>();
        }

        [Key]
        public int BLOG_ID { get; set; }

        public int CATEGORY_FID { get; set; }

        public int ADMIN_FID { get; set; }

        [Required]
        [StringLength(150)]
        public string BLOG_TITLE { get; set; }

        [Required]
        [StringLength(2000)]
        public string BLOG_DISCRIPTION { get; set; }

        [Required]
        [StringLength(100)]
        public string BLOG_PIC { get; set; }

        [NotMapped]
        public HttpPostedFileBase BLOG_IMAGE { get; set; }
        public DateTime BLOG_DATE { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual Blog_Category Blog_Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blog_Comment> Blog_Comment { get; set; }
    }
}
