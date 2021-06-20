namespace eHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appointment")]
    public partial class Appointment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Appointment()
        {
            Blood_Donation = new HashSet<Blood_Donation>();
            Feedbacks = new HashSet<Feedback>();
            Patient_Treatment = new HashSet<Patient_Treatment>();
        }

        [Key]
        public int APPOINTMENT_ID { get; set; }

        public int SCHEDULE_FID { get; set; }

        public int PATIENT_FID { get; set; }

        [Column(TypeName = "date")]
        public DateTime APPOINTMENT_DATE { get; set; }

        [Required]
        [StringLength(50)]
        public string TIME_SLOT { get; set; }

        [Required]
        [StringLength(20)]
        public string STATUS { get; set; }

        [NotMapped]
        public string PaymentMethod { get; set; }

        [NotMapped]
        public decimal DR_FEE { get; set; }
        public virtual Doctor_Schedule Doctor_Schedule { get; set; }

        public virtual Patient Patient { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blood_Donation> Blood_Donation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient_Treatment> Patient_Treatment { get; set; }
    }
}
