namespace eHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Blood_Doners
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Blood_Doners()
        {
            Blood_Donation = new HashSet<Blood_Donation>();
        }

        [Key]
        public int DONER_ID { get; set; }

        public int? ADMIN_FID { get; set; }

        [Required]
        [StringLength(50)]
        public string DONER_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string DONER_EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string DONER_CONTACT { get; set; }

        [Required]
        [StringLength(50)]
        public string DONER_DOB { get; set; }

        [Required]
        [StringLength(50)]
        public string BLOOD_GROUP { get; set; }

        [Required]
        [StringLength(50)]
        public string DONER_GENDER { get; set; }

        [Required]
        [StringLength(50)]
        public string DONER_CITY { get; set; }

        [Required]
        [StringLength(50)]
        public string DONER_STATUS { get; set; }

        public virtual Admin Admin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blood_Donation> Blood_Donation { get; set; }
    }
}
