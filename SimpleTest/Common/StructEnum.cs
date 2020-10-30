using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest.Common
{
    public class StructEnum
    {       
        public enum Enum_Permission
        {
            Xem,
            Them,
            Sua,
            Xoa,
            ChoPhep
        }

        public enum Enum_ToolstripButtonType
        {
            [Description("None")]
            None,
            [Description("Tìm kiếm")]
            TimKiem,
            [Description("Xem")]
            Xem,
            [Description("Thêm")]
            Them,
            [Description("Sửa")]
            Sua,
            [Description("Xóa")]
            Xoa,
            [Description("Copy")]
            SaoChep,
            [Description("Đóng")]
            Dong,
            [Description("Lưu")]
            Luu,
            [Description("Lưu và thêm")]
            LuuThem,
            [Description("Lưu và đóng")]
            LuuDong,

        }

        public enum PermissionTypes
        {
            NONE = 0,
            ADD = 1,
            SAVE = 2,
            DELETE = 3,
            SPECIAL = 4, /* phân quyền chức năng đặc biệt */
            TOOLSTRIPTYPE = 5 /* kiểm tra quyền theo toolstrip type */
        };

    }
}
