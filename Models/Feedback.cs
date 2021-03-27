namespace eHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        public int FEEDBACK_ID { get; set; }

        public int APPOINTMENT_FID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RATING { get; set; }

        [Column("FEEDBACK")]
        [StringLength(150)]
        public string FEEDBACK1 { get; set; }

        public virtual Appointment Appointment { get; set; }
    }
}
