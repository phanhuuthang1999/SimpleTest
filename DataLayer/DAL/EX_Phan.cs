namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EX_Phan
    {
        public long Id { get; set; }

        [StringLength(50)]
        public string MaPhan { get; set; }

        [StringLength(200)]
        public string TenPhan { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }
        public int? STT { get; set; }
        public long? IDMonHoc { get; set; }
    }
}
