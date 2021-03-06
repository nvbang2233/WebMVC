namespace WebMVCv13.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        public int ID { get; set; }

        [Required]

        [StringLength(50)]
        public string UserName { get; set; }
        [Required]

        [StringLength(50)]
        public string PassWord { get; set; }
    }
}
