namespace eHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Doctor")]
    public partial class Doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doctor()
        {
            Doctor_Schedule = new HashSet<Doctor_Schedule>();
        }

        [Key]
        public int DR_ID { get; set; }

        public int DEPARTMENT_FID { get; set; }

        [Required]
        [StringLength(50)]
        public string DR_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string DR_QUALIFICATION { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DR_SALARY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DR_CONTACT { get; set; }

        [Required]
        [StringLength(50)]
        public string DR_EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string DR_PASSWORD { get; set; }

        [Required]
        [StringLength(50)]
        public string DR_PIC { get; set; }

        [NotMapped]
        public HttpPostedFileBase DR_IMAGE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DR_FEE { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doctor_Schedule> Doctor_Schedule { get; set; }
    }
}
