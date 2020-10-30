namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EX_Chuong
    {
        public long Id { get; set; }

        public long? IDMonHoc { get; set; }

        public long? IDPhan { get; set; }

        [StringLength(50)]
        public string MaChuong { get; set; }

        [StringLength(200)]
        public string TenChuong { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }
        public int? STT { get; set; }        
    }
}
