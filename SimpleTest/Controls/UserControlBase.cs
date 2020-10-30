using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataLayer.BLL;
using DataLayer.DAL;
using static SimpleTest.Common.UICommon;
using SimpleTest.Common;

namespace SimpleTest.Controls
{
    public partial class UserControlBase : DevExpress.XtraEditors.XtraUserControl
    {

        #region Variable

        private ES_SoanCauHoiBLL _business = new ES_SoanCauHoiBLL();
        private EX_CauHoi _cauHoiCha = new EX_CauHoi();
        private List<EX_CauHoi> _listCauHoi = new List<EX_CauHoi>();
        private List<long> _listIdCauHoiBiXoa;
        private List<long> _listIdCauTraLoiBiXoa;
        private EX_CauHoi _cauHoiCurent;
        private long _idCauHoiCurent;
        private long _idCauTraLoi;
        private long? _idCauHoiCha;
        private int _idMucDoNhanThuc;
        private bool _isChanged;
        private long? _idDanhMuc;
        private int? _idLoaiCauHoi;

        #endregion

        public UserControlBase()
        {
            InitializeComponent();
        }

        #region Properties

        public EditorControl CurrentControl { get; set; }
        public ModeForm Mode { get; set; } = ModeForm.ThemMoi;
        public long? IdCauHoiCha { get => _idCauHoiCha; set => _idCauHoiCha = value; }
        public long IdCauHoiCurent { get => _idCauHoiCurent; set => _idCauHoiCurent = value; }
        public long IdCauTraLoi { get => _idCauTraLoi; set => _idCauTraLoi = value; }
        public EX_CauHoi CauHoiCurent { get => _cauHoiCurent; set => _cauHoiCurent = value; }
        public List<EX_CauHoi> ListCauHoi { get => _listCauHoi; set => _listCauHoi = value; }
        public int IdMucDoNhanThuc { get => _idMucDoNhanThuc; set => _idMucDoNhanThuc = value; }
        public bool IsChanged { get => _isChanged; set => _isChanged = value; }
        public long? IdDanhMuc { get => _idDanhMuc; set => _idDanhMuc = value; }
        public int? IdLoaiCauHoi { get => _idLoaiCauHoi; set => _idLoaiCauHoi = value; }
        public List<long> ListIdCauHoiBiXoa { get => _listIdCauHoiBiXoa; set => _listIdCauHoiBiXoa = value; }
        public List<long> ListIdCauTraLoiBiXoa { get => _listIdCauTraLoiBiXoa; set => _listIdCauTraLoiBiXoa = value; }

        #endregion
    }
}
