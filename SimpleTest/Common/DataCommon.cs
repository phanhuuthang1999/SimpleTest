using DataLayer.BLL;
using DataLayer.Common;
using DataLayer.DAL;
using SimpleTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataLayer.Common.LayerCommon;

namespace SimpleTest.Common
{
    public static class DataCommon
    {
        private static DanhMucBll _bus = new DanhMucBll();
        //public static void LoadDataCboKhoiLop(LookUpEditEx control)
        //{
        //    var lstItem = new List<LookUpEditItem>();
        //    lstItem.Add(new LookUpEditItem { ColumnName = "MaDanhMuc", ColumnCaption = "Mã khối lớp" });
        //    lstItem.Add(new LookUpEditItem { ColumnName = "TenDanhMuc", ColumnCaption = "Tên khối lớp" });
        //    var lstKhoilop = Cache.Context.EX_DanhMuc.Where(m=>m.IDLoaiDanhMuc == (int)Enum_LoaiDanhMuc.KhoiLop).ToList();
        //    control.SetData<EX_DanhMuc>(lstKhoilop, lstItem, "TenDanhMuc", "Id");
        //}

        //public static void LoadDataCboMonHoc(LookUpEditEx control, long? idKhoiLop)
        //{
        //    var lstItem = new List<LookUpEditItem>();
        //    lstItem.Add(new LookUpEditItem { ColumnName = "MaDanhMuc", ColumnCaption = "Mã môn học" });
        //    lstItem.Add(new LookUpEditItem { ColumnName = "TenDanhMuc", ColumnCaption = "Tên môn học" });
        //    var lstMonHoc = _bus.GetDanhSachMonHoc(idKhoiLop, null, "", "");
        //    control.SetData<EX_DanhMuc>(lstMonHoc, lstItem, "TenDanhMuc", "Id");
        //}

        //public static void LoadDataCboPhan(LookUpEditEx control, long? idKhoiLop, long? idMonHoc)
        //{
        //    var lstItem = new List<LookUpEditItem>();
        //    lstItem.Add(new LookUpEditItem { ColumnName = "MaDanhMuc", ColumnCaption = "Mã nội dung kiến thức" });
        //    lstItem.Add(new LookUpEditItem { ColumnName = "TenDanhMuc", ColumnCaption = "Tên nội dung kiến thức" });
        //    var lstPhan = _bus.GetDanhSachPhan(idKhoiLop, idMonHoc, null, "", "");
        //    control.SetData<EX_DanhMuc>(lstPhan, lstItem, "TenDanhMuc", "Id");
        //}

        //public static void LoadDataCboChuong(LookUpEditEx control, long? idKhoiLop, long? idMonHoc, long? idPhan)
        //{
        //    var lstItem = new List<LookUpEditItem>();
        //    lstItem.Add(new LookUpEditItem { ColumnName = "MaDanhMuc", ColumnCaption = "Mã đơn vị kiến thức" });
        //    lstItem.Add(new LookUpEditItem { ColumnName = "TenDanhMuc", ColumnCaption = "Tên đơn vị kiến thức" });
        //    var lstChuong = _bus.GetDanhSachChuong(idKhoiLop, idMonHoc, idPhan, null, "", "");
        //    control.SetData<EX_DanhMuc>(lstChuong, lstItem, "TenDanhMuc", "Id");
        //}

        //public static void LoadDataDoKho(LookUpEditEx control)
        //{
        //    var lstData = Cache.Context.EX_DoKho.ToList();
        //    var lstItem = new List<LookUpEditItem>();
        //    lstItem.Add(new LookUpEditItem { ColumnName = "Id", ColumnCaption = "Id" });
        //    lstItem.Add(new LookUpEditItem { ColumnName = "MaDoKho", ColumnCaption = "Mã độ khó" });
        //    lstItem.Add(new LookUpEditItem { ColumnName = "TenDoKho", ColumnCaption = "Tên độ khó" });
        //    control.SetData(lstData, lstItem, "TenDoKho", "Id");
        //}

        //public static void LoadDataLoaiCauHoi(LookUpEditEx control)
        //{
        //    var lstLoaiCauHoi = new List<DM_STT>();
        //    lstLoaiCauHoi.Add(new DM_STT() { Id = (int)LoaiCauHoi.CauHoiTracNghiem, Ten = LoaiCauHoi.CauHoiTracNghiem.GetDescription() });
        //    lstLoaiCauHoi.Add(new DM_STT() { Id = (int)LoaiCauHoi.CauHoiTracNghiemNhom, Ten = LoaiCauHoi.CauHoiTracNghiemNhom.GetDescription() });
        //    lstLoaiCauHoi.Add(new DM_STT() { Id = (int)LoaiCauHoi.CauHoiGachChan, Ten = LoaiCauHoi.CauHoiGachChan.GetDescription() });
        //    lstLoaiCauHoi.Add(new DM_STT() { Id = (int)LoaiCauHoi.CauHoiDienKhuyet, Ten = LoaiCauHoi.CauHoiDienKhuyet.GetDescription() });
        //    lstLoaiCauHoi.Add(new DM_STT() { Id = (int)LoaiCauHoi.CauHoiDungSai, Ten = LoaiCauHoi.CauHoiDungSai.GetDescription() });
        //    lstLoaiCauHoi.Add(new DM_STT() { Id = (int)LoaiCauHoi.CauHoiDungSaiNhom, Ten = LoaiCauHoi.CauHoiDungSaiNhom.GetDescription() });
        //    lstLoaiCauHoi.Add(new DM_STT() { Id = (int)LoaiCauHoi.CauHoiNoiCheo, Ten = LoaiCauHoi.CauHoiNoiCheo.GetDescription() });
        //    lstLoaiCauHoi.Add(new DM_STT() { Id = (int)LoaiCauHoi.CauHoiSapXepDoanVan, Ten = LoaiCauHoi.CauHoiSapXepDoanVan.GetDescription() });
        //    lstLoaiCauHoi.Add(new DM_STT() { Id = (int)LoaiCauHoi.CauHoiHoanThanhCau, Ten = LoaiCauHoi.CauHoiHoanThanhCau.GetDescription() });
        //    lstLoaiCauHoi.Add(new DM_STT() { Id = (int)LoaiCauHoi.CauHoiTuLuan, Ten = LoaiCauHoi.CauHoiTuLuan.GetDescription() });
        //    lstLoaiCauHoi.Add(new DM_STT() { Id = (int)LoaiCauHoi.CauHoiTuLuanNhom, Ten = LoaiCauHoi.CauHoiTuLuanNhom.GetDescription() });

        //    var lstItem = new List<LookUpEditItem>();
        //    lstItem.Add(new LookUpEditItem { ColumnName = "Id", ColumnCaption = "Id" });
        //    lstItem.Add(new LookUpEditItem { ColumnName = "Ten", ColumnCaption = "Tên" });
        //    control.SetData(lstLoaiCauHoi, lstItem, "Ten", "Id");
        //}
    }
}
