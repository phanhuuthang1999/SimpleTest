namespace DataLayer.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EX_DanhMuc
    {
        public long Id { get; set; }

        public long? IDDanhMucCha { get; set; }

        [StringLength(50)]
        public string MaDanhMuc { get; set; }

        [StringLength(200)]
        public string TenDanhMuc { get; set; }

        public int? IDLoaiDanhMuc { get; set; }

        public int? STT { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }
    }
}
