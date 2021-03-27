namespace eHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Admin")]
    public partial class Admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin()
        {
            Blogs = new HashSet<Blog>();
            Blood_Doners = new HashSet<Blood_Doners>();
        }

        [Key]
        public int ADMIN_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_PASSWORD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ADMIN_CONTACT { get; set; }

        [StringLength(100)]
        public string ADMIN_PIC { get; set; }

        [NotMapped]
        public HttpPostedFileBase ADMIN_IMAGE { get; set; }

        [NotMapped]

        public string lOGIN_AS { get; set; }

        public int? ROLE_FID { get; set; }

        public virtual Admin_Role Admin_Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blog> Blogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blood_Doners> Blood_Doners { get; set; }
    }
}
