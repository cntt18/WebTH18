namespace WebApplication1.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSp { get; set; }

        [StringLength(50)]
        public string TenSp { get; set; }

        [StringLength(50)]
        public string GiaSp { get; set; }

        [StringLength(50)]
        public string MoTa { get; set; }

        public int? MaDm { get; set; }
    }
}
