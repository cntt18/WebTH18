namespace WebApplication1.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSp { get; set; }

        [StringLength(10)]
        public string SoLuong { get; set; }

        [StringLength(50)]
        public string DonGia { get; set; }
    }
}
