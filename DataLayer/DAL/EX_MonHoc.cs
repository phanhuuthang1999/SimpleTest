namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EX_MonHoc
    {
        public long Id { get; set; }

        [StringLength(50)]
        public string MaMonHoc { get; set; }

        [StringLength(200)]
        public string TenMonHoc { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }
        public int? STT { get; set; }
        public long? IDKhoiLop { get; set; }
    }
}
