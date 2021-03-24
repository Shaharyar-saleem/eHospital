namespace eHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Doctor_Schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doctor_Schedule()
        {
            Appointments = new HashSet<Appointment>();
        }

        [Key]
        public int SCHEDULE_ID { get; set; }

        public int DR_FID { get; set; }

        [Required]
        [StringLength(60)]
        public string AVAILABLE_DAYS { get; set; }

        [Required]
        [StringLength(50)]
        public string START_TIME { get; set; }

        [Required]
        [StringLength(50)]
        public string END_TIME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MAX_APPOINTMENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
