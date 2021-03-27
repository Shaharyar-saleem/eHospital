namespace eHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Blood_Donation
    {
        [Key]
        public int DONATION_ID { get; set; }

        public int DONER_FID { get; set; }

        public int APPOINTMENT_FID { get; set; }

        public virtual Appointment Appointment { get; set; }

        public virtual Blood_Doners Blood_Doners { get; set; }
    }
}
