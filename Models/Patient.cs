namespace eHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        [Key]
        public int PATIENT_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PATIENT_NAME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PATIENT_CONTACT { get; set; }

        [Required]
        [StringLength(50)]
        public string PATIENT_EMAIL { get; set; }

        [Required]
        [StringLength(15)]
        public string PATIENT_PASSWORD { get; set; }

        [Column(TypeName = "date")]
        public DateTime PATIENT_DOB { get; set; }

        [Required]
        [StringLength(10)]
        public string PATIENT_GENDER { get; set; }

        [Required]
        [StringLength(50)]
        public string PATIENT_CITY { get; set; }

        [StringLength(100)]
        public string PATIENT_PIC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
