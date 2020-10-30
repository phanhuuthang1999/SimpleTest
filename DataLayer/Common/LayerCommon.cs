using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DataLayer.Common
{
    public static class LayerCommon
    {
        #region Enum

        public enum Enum_LoaiDanhMuc
        {
            [Description("Hệ thống")]
            HeThong = 1,
            [Description("Khối lớp")]
            KhoiLop = 2,
            [Description("Môn học")]
            MonHoc = 3,
            [Description("Nội dung kiến thức")]
            NoiDungKienThuc = 4,
            [Description("Đơn vị kiến thức")]
            DonViKienThuc = 5,
            [Description("Bài học")]
            BaiHoc = 6
        }

        #endregion

        public static string GetDescription(this Enum val)
        {
            string name = Enum.GetName(val.GetType(), val);

            System.Reflection.FieldInfo obj = val.GetType().GetField(name);

            if (obj != null)
            {
                object[] attributes = obj.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

                return attributes.Length > 0 ? ((System.ComponentModel.DescriptionAttribute)attributes[0]).Description : null;
            }

            return null;
        }


    }
}
