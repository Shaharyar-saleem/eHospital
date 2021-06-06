namespace eHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Patient_Treatment
    {
        [Key]
        public int TREATMENT_ID { get; set; }

        public int APPOINTMENT_FID { get; set; }

        [Required]
        [StringLength(100)]
        public string SYMPTOMS { get; set; }

        [Required]
        [StringLength(150)]
        public string PRESCRIPTION { get; set; }

        [StringLength(150)]
        public string DESCRIPTION { get; set; }

        
        public virtual Appointment Appointment { get; set; }
    }
}
