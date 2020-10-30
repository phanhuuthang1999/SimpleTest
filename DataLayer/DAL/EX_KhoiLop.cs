namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EX_KhoiLop
    {
        public long Id { get; set; }

        [StringLength(50)]
        public string MaKhoiLop { get; set; }

        [StringLength(200)]
        public string TenKhoiLop { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }
        public int? STT { get; set; }

    }
}
