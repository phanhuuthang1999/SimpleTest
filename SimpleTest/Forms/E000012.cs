using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using System.Collections;
using DataLayer.BLL;
using DevExpress.XtraGrid;
using DevExpress.Utils.Menu;
using DevExpress.XtraTreeList.Localization;
using DataLayer.DAL;
using SimpleTest.Controls;
using System.IO;
using System.Diagnostics;
using SimpleTest.Common;
using static PMT.EXAM.DISPLAY.UiCommon;
using static SimpleTest.Common.UICommon;

namespace SimpleTest.Forms
{
    /// <summary>
    /// Soạn câu hỏi
    /// </summary>
    public partial class E000012 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Variable

        private DanhMucBll _bus = new DanhMucBll();
        private EX_DanhMuc _currentNode;
        private EditorControl _currentTextControl;
        private CaptureCT _frmct = null;
        private string _mathToolPath = Application.StartupPath + "\\Addon\\EQNEDT32.exe";
        private string _mathTypePath = "C:\\Program Files (x86)\\MathType\\MathType.exe";
        private string _mathTypePath64 = "C:\\Programfiles\\MathType\\MathType.exe";
        private Timer _timer;

        #endregion

        #region UserControl

        private EX_CauHoi _curentCauHoi;
        private long _idCauHoi;
        private long _idCauHoiCha;
        private bool _isCauHoiCha;
        private long? _idDanhMuc;
        private long? _idLoaiCauHoi;
        private ModeForm _mode = ModeForm.ThemMoi;

        private UserControlBase _currentUserControl;

        private UcTracNghiemDon _pmtCauHoiLuaChonDon1;
        private UcTracNghiemChum _pmtCauHoiLuaChonChum1;
        private UcGachChanDon _pmtCauHoiGachChanDon1;
        private UcTuLuanDon _pmtCauHoiTuluanDon1;
        private UcTuLuanChum _pmtCauHoiTuluanChum1;
        private bool _isHasLoad = false;

        private UcDienKhuyetChum _pmtCauHoiDienKhuyetChum1;
        private UcDungSaiDon _pmtCauHoiDungSaiDon1;
        private UcDungSaiChum _pmtCauHoiDungSaiChum1;
        private UcNoiCheoDon _pmtCauHoiNoiCheoDon1;
        private UcSapXepCau _pmtCauHoiSapXep;
        private UcHoanThanhCau _pmtCauHoiHoanThanhCau;

        #endregion

        #region Constructor

        public E000012()
        {
            InitializeComponent();
            InitForm();
        }

        #endregion

        #region Private

        private void InitForm()
        {
            #region Cbo

            DataCommon.LoadDataDoKho(cboMucDoNhanThuc);
            DataCommon.LoadDataLoaiCauHoi(cboLoaiCauHoi);
            cboMucDoNhanThuc.CategoryID = 1;
            #endregion

            #region TreeList

            treeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            treeList1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Blue;

            SearchDataTree();

            treeList1.GetSelectImage += TreeList1_GetSelectImage;
            treeList1.FocusedNodeChanged += TreeList1_FocusedNodeChanged;
            treeList1.PopupMenuShowing += TreeList1_PopupMenuShowing;

            treeList1.Columns["TenDanhMuc"].SortMode = ColumnSortMode.Custom;
            treeList1.CustomColumnSort += TreeList1_CustomColumnSort;


            #endregion

            #region TsbButton

            tsbAdd.ItemClick += TsbAdd_ItemClick;
            tsbSave.ItemClick += TsbSave_ItemClick;
            tsbCut.ItemClick += TsbCut_ItemClick;
            tsbCopy.ItemClick += TsbCopy_ItemClick;
            tsbPaste.ItemClick += TsbPaste_ItemClick;
            tsbDelete.ItemClick += TsbDelete_ItemClick;
            tsbBold.ItemClick += TsbBold_ItemClick;
            tsbItalic.ItemClick += TsbItalic_ItemClick;
            tsbUnderline.ItemClick += TsbUnderline_ItemClick;
            tsbLeft.ItemClick += TsbLeft_ItemClick;
            tsbCenter.ItemClick += TsbCenter_ItemClick;
            tsbRight.ItemClick += TsbRight_ItemClick;
            tsbFont.ItemClick += TsbFont_ItemClick;
            tsbForeColor.ItemClick += TsbForeColor_ItemClick;
            tsbBackcolor.ItemClick += TsbBackcolor_ItemClick;
            tsbInsertImage.ItemClick += TsbInsertImage_ItemClick;
            tsbInsertSymbol.ItemClick += TsbInsertSymbol_ItemClick;
            tsbMath.ItemClick += TsbMath_ItemClick;
            tsbCapture.ItemClick += TsbCapture_ItemClick;
            tsbClose.ItemClick += TsbClose_ItemClick;

            #endregion

            SetupTimer();
        }

        private void SetupTimer()
        {
            _timer = new Timer();
            _timer.Interval = 200;
            _timer.Tick += new EventHandler(timer_Tick);
            _timer.Start();
        }

        private void SearchDataTree()
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            long idDanhMuc = 0;
            if (_currentNode != null)
            {
                idDanhMuc = _currentNode.Id;
            }

            var data = _bus.GetAllDanhMuc();
            treeList1.DataSource = data;
            treeList1.Refresh();
            treeList1.ExpandAll();

            SetFocusNode(idDanhMuc);

            SplashScreenManager.CloseForm(false);
        }

        private void SetFocusNode(long idDanhMuc)
        {
            var selected_node = treeList1.FindNodeByFieldValue("Id", idDanhMuc);
            if (selected_node != null)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    treeList1.FocusedNode = selected_node;
                }));
            }
        }

        private void AddNewCauHoi(bool isPressButton = false)
        {
            if (!_bus.CheckDuocPhepSoanCauHoi(_currentNode?.IDLoaiDanhMuc))
            {
                if (isPressButton) UICommon.ShowMsgWarningString("Danh mục không được phép soạn câu hỏi");
                return;
            }
            ClearAllData();
            if (_currentNode != null)
            {
                IdDanhMuc = _currentNode.Id;
                _idLoaiCauHoi = cboLoaiCauHoi.CategoryID;
                LoadModulCauHoi();
            }
            else
            {
                UICommon.ShowMsgWarningString("Bạn chưa chọn danh mục");
                return;
            }
        }

        #region Control soạn thảo

        private void FormulerButton(Point p)
        {
            SymbolForm frm = new SymbolForm();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.OnSelectedSymbol += frm_OnSelectedSymbol;
            frm.ShowDialog();
        }

        private void OpenFileFormula()
        {
            var text = "";
            if (!File.Exists(_mathTypePath) && !File.Exists(_mathTypePath64))
            {
                text = SimpleTest.Properties.Resources.equation;
                Process[] pname = Process.GetProcessesByName("Equation");
                if (pname.Length == 0)
                {
                    Process process = new Process();
                    process.StartInfo.FileName = _mathToolPath;
                    process.StartInfo.Arguments = null;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.ErrorDialog = false;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.Start();
                }
            }
            else
            {
                text = SimpleTest.Properties.Resources.equation2;
                Process[] pname = Process.GetProcessesByName("MathType");
                if (pname.Length == 0)
                {
                    Process process = new Process();
                    process.StartInfo.FileName = File.Exists(_mathTypePath) ? _mathTypePath : _mathTypePath64;
                    process.StartInfo.Arguments = null;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.ErrorDialog = false;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.Start();
                }
            }

            if (_currentTextControl != null && _currentTextControl.CanFocus && !_currentTextControl.IsUnderline())
            {
                Clipboard.Clear();
                var index = _currentTextControl.SelectionStart;
                _currentTextControl.SelectedRtf = text;
                _currentTextControl.SelectionStart = index + 1;
                _currentTextControl.SelectionLength = 1;
                _currentTextControl.SelectedText = "";
            }
        }

        #endregion

        #region UserControl

        private void ClearAllData()
        {
            IdCauHoi = 0;
            IdCauHoiCha = 0;
            IsCauHoiCha = false;
            CurentCauHoi = new EX_CauHoi();
            Mode = ModeForm.ThemMoi;
            _isHasLoad = false;
            cboLoaiCauHoi.Enabled = true;
        }

        private void LoadModulCauHoi()
        {
            if (!_isHasLoad)
            {
                if (!cboLoaiCauHoi.CategoryID.HasValue)
                {
                    UICommon.ShowMsgWarningString("Bạn chưa chọn loại câu hỏi!");
                    return;
                }
                if (!cboMucDoNhanThuc.CategoryID.HasValue)
                {
                    UICommon.ShowMsgWarningString("Bạn chưa chọn độ khó cho câu hỏi!");
                    return;
                }

                var loaiCauHoi = cboLoaiCauHoi.CategoryID;
                switch ((LoaiCauHoi)loaiCauHoi)
                {
                    #region Cau hoi lua chon

                    case LoaiCauHoi.CauHoiTracNghiem:

                        _pmtCauHoiLuaChonDon1 = new UcTracNghiemDon();
                        if (!pnMain.Controls.Contains(_pmtCauHoiLuaChonDon1))
                        {
                            pnMain.Controls.Clear();
                            pnMain.Controls.Add(_pmtCauHoiLuaChonDon1);
                        }
                        _pmtCauHoiLuaChonDon1.CauHoiCurent = CurentCauHoi;
                        _pmtCauHoiLuaChonDon1.IdCauHoiCurent = IdCauHoi;
                        _pmtCauHoiLuaChonDon1.Mode = Mode;
                        _pmtCauHoiLuaChonDon1.CauHoiLoad();
                        _currentUserControl = _pmtCauHoiLuaChonDon1;
                        break;

                    #endregion

                    #region Trac nghiem nhom

                    case LoaiCauHoi.CauHoiTracNghiemNhom:
                        //Cau hoi lua chon chum
                        _pmtCauHoiLuaChonChum1 = new UcTracNghiemChum();
                        if (!pnMain.Controls.Contains(_pmtCauHoiLuaChonChum1))
                        {
                            pnMain.Controls.Clear();
                            pnMain.Controls.Add(_pmtCauHoiLuaChonChum1);
                        }
                        _pmtCauHoiLuaChonChum1.Mode = Mode;
                        _pmtCauHoiLuaChonChum1.IdCauHoiCha = IdCauHoiCha;
                        _pmtCauHoiLuaChonChum1.IdCauHoiCurent = IdCauHoi;
                        _pmtCauHoiLuaChonChum1.CauHoiLoad();
                        _currentUserControl = _pmtCauHoiLuaChonChum1;
                        break;

                    #endregion

                    #region Cau hoi gach chan

                    case LoaiCauHoi.CauHoiGachChan:
                        //Cau hoi gach chan - don
                        _pmtCauHoiGachChanDon1 = new UcGachChanDon();
                        if (!pnMain.Controls.Contains(_pmtCauHoiGachChanDon1))
                        {
                            pnMain.Controls.Clear();
                            pnMain.Controls.Add(_pmtCauHoiGachChanDon1);
                        }
                        _pmtCauHoiGachChanDon1.CauHoiCurent = CurentCauHoi;
                        _pmtCauHoiGachChanDon1.IdCauHoiCurent = IdCauHoi;
                        _pmtCauHoiGachChanDon1.Mode = Mode;
                        _pmtCauHoiGachChanDon1.CauHoiLoad();
                        _currentUserControl = _pmtCauHoiGachChanDon1;
                        break;

                    #endregion

                    #region Cau hoi dien khuyet

                    case LoaiCauHoi.CauHoiDienKhuyet:
                        _pmtCauHoiDienKhuyetChum1 = new UcDienKhuyetChum();
                        if (!pnMain.Controls.Contains(_pmtCauHoiDienKhuyetChum1))
                        {
                            pnMain.Controls.Clear();
                            pnMain.Controls.Add(_pmtCauHoiDienKhuyetChum1);
                        }
                        _pmtCauHoiDienKhuyetChum1.Mode = Mode;
                        _pmtCauHoiDienKhuyetChum1.IdCauHoiCha = IdCauHoiCha;
                        _pmtCauHoiDienKhuyetChum1.IdCauHoiCurent = IdCauHoi;
                        _pmtCauHoiDienKhuyetChum1.CauHoiLoad();
                        _currentUserControl = _pmtCauHoiDienKhuyetChum1;
                        break;

                    #endregion

                    #region Cau hoi dung sai

                    case LoaiCauHoi.CauHoiDungSai:
                        //Cau hoi dung sai - don
                        _pmtCauHoiDungSaiDon1 = new UcDungSaiDon();
                        if (!pnMain.Controls.Contains(_pmtCauHoiDungSaiDon1))
                        {
                            pnMain.Controls.Clear();
                            pnMain.Controls.Add(_pmtCauHoiDungSaiDon1);
                        }

                        _pmtCauHoiDungSaiDon1.CauHoiCurent = CurentCauHoi;
                        _pmtCauHoiDungSaiDon1.IdCauHoiCurent = IdCauHoi;
                        _pmtCauHoiDungSaiDon1.Mode = Mode;
                        _pmtCauHoiDungSaiDon1.CauHoiLoad();
                        _currentUserControl = _pmtCauHoiDungSaiDon1;
                        break;

                    #endregion

                    #region Dung sai nhom

                    case LoaiCauHoi.CauHoiDungSaiNhom:
                        //Cau hoi đúng sai chum
                        _pmtCauHoiDungSaiChum1 = new UcDungSaiChum();
                        if (!pnMain.Controls.Contains(_pmtCauHoiDungSaiChum1))
                        {
                            pnMain.Controls.Clear();
                            pnMain.Controls.Add(_pmtCauHoiDungSaiChum1);
                        }
                        _pmtCauHoiDungSaiChum1.Mode = Mode;
                        _pmtCauHoiDungSaiChum1.IdCauHoiCha = IdCauHoiCha;
                        _pmtCauHoiDungSaiChum1.IdCauHoiCurent = IdCauHoi;
                        _pmtCauHoiDungSaiChum1.CauHoiLoad();
                        _currentUserControl = _pmtCauHoiDungSaiChum1;
                        break;

                    #endregion

                    #region Cau hoi nối cheo

                    case LoaiCauHoi.CauHoiNoiCheo:
                        //Cau hoi nối cheo
                        _pmtCauHoiNoiCheoDon1 = new UcNoiCheoDon();
                        if (!pnMain.Controls.Contains(_pmtCauHoiNoiCheoDon1))
                        {
                            pnMain.Controls.Clear();
                            pnMain.Controls.Add(this._pmtCauHoiNoiCheoDon1);
                        }
                        _pmtCauHoiNoiCheoDon1.CauHoiCurent = CurentCauHoi;
                        _pmtCauHoiNoiCheoDon1.IdCauHoiCurent = IdCauHoi;
                        _pmtCauHoiNoiCheoDon1.Mode = Mode;
                        _pmtCauHoiNoiCheoDon1.CauHoiLoad();
                        _currentUserControl = _pmtCauHoiNoiCheoDon1;
                        break;

                    #endregion

                    #region Cau hoi sap xep

                    case LoaiCauHoi.CauHoiSapXepDoanVan:
                        //Cau hoi nối cheo
                        _pmtCauHoiSapXep = new UcSapXepCau();
                        if (!pnMain.Controls.Contains(_pmtCauHoiSapXep))
                        {
                            pnMain.Controls.Clear();
                            pnMain.Controls.Add(this._pmtCauHoiSapXep);
                        }
                        var cauHoiCha = _bus.Context.EX_CauHoi.FirstOrDefault(m => m.Id == IdCauHoiCha);
                        if (cauHoiCha != null)
                        {
                            cauHoiCha.ListCauHoi = _bus.Context.EX_CauHoi.Where(m => m.IDCauHoiCha == IdCauHoiCha).ToList();
                            cauHoiCha.ListCauHoi.ForEach(m => m.ListCauTraLoi = _bus.GetCauTraLoi(m.Id));
                        }
                        _pmtCauHoiSapXep.CauHoiCurent = cauHoiCha;
                        _pmtCauHoiSapXep.Mode = Mode;
                        _pmtCauHoiSapXep.CauHoiLoad();
                        _currentUserControl = _pmtCauHoiSapXep;
                        break;

                    #endregion

                    #region Cau hoi hoan thanh cau

                    case LoaiCauHoi.CauHoiHoanThanhCau:
                        //Cau hoi nối cheo
                        _pmtCauHoiHoanThanhCau = new UcHoanThanhCau();
                        if (!pnMain.Controls.Contains(_pmtCauHoiHoanThanhCau))
                        {
                            pnMain.Controls.Clear();
                            pnMain.Controls.Add(this._pmtCauHoiHoanThanhCau);
                        }
                        var cauHoiChaHt = _bus.Context.EX_CauHoi.FirstOrDefault(m => m.Id == IdCauHoiCha);
                        if (cauHoiChaHt != null)
                        {
                            cauHoiChaHt.ListCauHoi = _bus.Context.EX_CauHoi.Where(m => m.IDCauHoiCha == IdCauHoiCha).ToList();
                            cauHoiChaHt.ListCauHoi.ForEach(m => m.ListCauTraLoi = _bus.GetCauTraLoi(m.Id));
                        }
                        _pmtCauHoiHoanThanhCau.CauHoiCurent = cauHoiChaHt;
                        _pmtCauHoiHoanThanhCau.Mode = Mode;
                        _pmtCauHoiHoanThanhCau.CauHoiLoad();
                        _currentUserControl = _pmtCauHoiHoanThanhCau;
                        break;

                    #endregion

                    #region Cau hoi tu luan

                    case LoaiCauHoi.CauHoiTuLuan:

                        //Cau hoi tu luan don
                        _pmtCauHoiTuluanDon1 = new UcTuLuanDon();
                        if (!pnMain.Controls.Contains(_pmtCauHoiTuluanDon1))
                        {
                            pnMain.Controls.Clear();
                            pnMain.Controls.Add(this._pmtCauHoiTuluanDon1);
                        }
                        _pmtCauHoiTuluanDon1.CauHoiCurent = CurentCauHoi;
                        _pmtCauHoiTuluanDon1.IdCauHoiCurent = IdCauHoi;
                        _pmtCauHoiTuluanDon1.Mode = Mode;
                        _pmtCauHoiTuluanDon1.CauHoiLoad();
                        _currentUserControl = _pmtCauHoiTuluanDon1;
                        break;
                    #endregion

                    #region Tu luan nhom

                    case LoaiCauHoi.CauHoiTuLuanNhom:
                        //Cau hoi tu luan chum
                        _pmtCauHoiTuluanChum1 = new UcTuLuanChum();
                        if (!pnMain.Controls.Contains(_pmtCauHoiTuluanChum1))
                        {
                            pnMain.Controls.Clear();
                            pnMain.Controls.Add(_pmtCauHoiTuluanChum1);
                        }
                        _pmtCauHoiTuluanChum1.Mode = Mode;
                        _pmtCauHoiTuluanChum1.IdCauHoiCha = IdCauHoiCha;
                        _pmtCauHoiTuluanChum1.IdCauHoiCurent = IdCauHoi;
                        _pmtCauHoiTuluanChum1.CauHoiLoad();
                        _currentUserControl = _pmtCauHoiTuluanChum1;
                        break;

                        #endregion
                }
            }

        }

        private void LoadDataControl()
        {
            #region Cau hoi cha
            if (IsCauHoiCha)
            {
                if (IdCauHoiCha > 0)
                {
                    var cauHoi = _bus.Context.EX_CauHoi.FirstOrDefault(m => m.Id == IdCauHoiCha);
                    if (cauHoi != null)
                    {
                        IdCauHoiCha = cauHoi.Id;
                        IdDanhMuc = cauHoi.IDChuong;
                        _idLoaiCauHoi = cauHoi.IDLoaiCauHoi;
                        //Gan lai cau hoi                        
                        cboLoaiCauHoi.CategoryID = cauHoi.IDLoaiCauHoi;
                        cboMucDoNhanThuc.CategoryID = cauHoi.DoKho;
                    }
                }
            }
            #endregion

            #region Cau hoi don

            else
            {
                if (IdCauHoi > 0)
                {
                    var cauHoi = _bus.GetById(IdCauHoi);
                    if (cauHoi != null)
                    {
                        if (cauHoi.IDLoaiCauHoi == (int)LoaiCauHoi.CauHoiTracNghiem || cauHoi.IDLoaiCauHoi == (int)LoaiCauHoi.CauHoiGachChan || cauHoi.IDLoaiCauHoi == (int)LoaiCauHoi.CauHoiDungSai)
                        {
                            var lstCauTraLoi = _bus.GetCauTraLoi(cauHoi.Id);
                            cauHoi.ListCauTraLoi = lstCauTraLoi;
                        }

                        if (cauHoi.IDLoaiCauHoi == (int)LoaiCauHoi.CauHoiNoiCheo)
                        {
                            var lstCauTraLoi = _bus.GetCauTraLoi(cauHoi.Id);
                            cauHoi.ListCauTraLoi = lstCauTraLoi.Where(m => m.IsVeTrai.HasValue && m.IsVeTrai.Value).ToList();
                            cauHoi.ListCauTraLoiPhai = lstCauTraLoi.Where(m => !m.IsVeTrai.HasValue || (m.IsVeTrai.HasValue && !m.IsVeTrai.Value)).ToList();
                        }
                        //Gan lai cau hoi
                        CurentCauHoi = cauHoi;
                        IdCauHoi = cauHoi.Id;
                        IdDanhMuc = cauHoi.IDChuong;
                        _idLoaiCauHoi = cauHoi.IDLoaiCauHoi;
                        cboLoaiCauHoi.CategoryID = cauHoi.IDLoaiCauHoi;
                        cboMucDoNhanThuc.CategoryID = cauHoi?.DoKho;
                    }
                }
            }
            #endregion

            LoadModulCauHoi();
            SetFocusNode(IdDanhMuc ?? 0);
        }

        private bool ValidateNoiDungManHinhChinh()
        {
            if (!cboLoaiCauHoi.CategoryID.HasValue)
            {
                UICommon.ShowMsgWarningString("Bạn hãy chọn loại câu hỏi.");
                return false;
            }

            if (!cboMucDoNhanThuc.CategoryID.HasValue)
            {
                UICommon.ShowMsgWarningString("Bạn chưa chọn mức độ nhận thức.");
                return false;
            }

            return true;
        }

        private void SaveCauHoi()
        {
            if (ValidateNoiDungManHinhChinh())
            {
                if (pnMain.Controls.Count == 0)
                {
                    UICommon.ShowMsgWarningString("Bạn chưa soạn câu hỏi");
                    return;
                }
                var loaiCauHoi = cboLoaiCauHoi.CategoryID;

                switch ((LoaiCauHoi)loaiCauHoi)
                {
                    #region Cau hoi lua chon

                    case LoaiCauHoi.CauHoiTracNghiem:
                        if (_pmtCauHoiLuaChonDon1 != null && _pmtCauHoiLuaChonDon1.ValidateNoiDung())
                        {
                            if (UICommon.ShowMsgQuestionString("Bạn muốn lưu câu hỏi hiện tại?") != DialogResult.Yes)
                                return;
                            _pmtCauHoiLuaChonDon1.IdMucDoNhanThuc = (int)cboMucDoNhanThuc.CategoryID;
                            _pmtCauHoiLuaChonDon1.IdDanhMuc = IdDanhMuc;
                            _pmtCauHoiLuaChonDon1.IdLoaiCauHoi = (int)_idLoaiCauHoi;
                            if (Mode == ModeForm.ThemMoi)
                            {
                                if (!_pmtCauHoiLuaChonDon1.SaveCauHoiNew())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            else
                            {
                                if (!_pmtCauHoiLuaChonDon1.SaveUpdateCauHoi())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            ClearAllData();
                            LoadModulCauHoi();
                            UICommon.ShowMsgUpdateSuccess();
                        }
                        break;

                    #endregion

                    #region Trac nghiem nhom

                    case LoaiCauHoi.CauHoiTracNghiemNhom:
                        if (_pmtCauHoiLuaChonChum1 != null && _pmtCauHoiLuaChonChum1.ValidateNoiDung())
                        {
                            if (UICommon.ShowMsgQuestionString("Bạn muốn lưu câu hỏi hiện tại?") != DialogResult.Yes)
                                return;
                            _pmtCauHoiLuaChonChum1.IdDanhMuc = IdDanhMuc;
                            _pmtCauHoiLuaChonChum1.IdLoaiCauHoi = (int)_idLoaiCauHoi;
                            _pmtCauHoiLuaChonChum1.IdMucDoNhanThuc = (int)cboMucDoNhanThuc.CategoryID;
                            if (Mode == ModeForm.ThemMoi)
                            {
                                if (!_pmtCauHoiLuaChonChum1.SaveNewCauHoi())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            else
                            {
                                if (!_pmtCauHoiLuaChonChum1.SaveUpdateCauHoi())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            ClearAllData();
                            LoadModulCauHoi();
                            UICommon.ShowMsgUpdateSuccess();
                        }
                        break;

                    #endregion

                    #region Cau hoi gach chan

                    case LoaiCauHoi.CauHoiGachChan:
                        if (_pmtCauHoiGachChanDon1 != null && _pmtCauHoiGachChanDon1.ValidateNoiDung())
                        {
                            if (UICommon.ShowMsgQuestionString("Bạn muốn lưu câu hỏi hiện tại?") != DialogResult.Yes)
                                return;
                            _pmtCauHoiGachChanDon1.IdMucDoNhanThuc = (int)cboMucDoNhanThuc.CategoryID;
                            _pmtCauHoiGachChanDon1.IdDanhMuc = IdDanhMuc;
                            _pmtCauHoiGachChanDon1.IdLoaiCauHoi = (int)_idLoaiCauHoi;
                            if (Mode == ModeForm.ThemMoi)
                            {
                                if (!_pmtCauHoiGachChanDon1.SaveCauHoiNew())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            else
                            {
                                if (!_pmtCauHoiGachChanDon1.SaveUpdateCauHoi())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            ClearAllData();
                            LoadModulCauHoi();
                            UICommon.ShowMsgUpdateSuccess();
                        }
                        break;

                    #endregion

                    #region Cau hoi dien khuyet

                    case LoaiCauHoi.CauHoiDienKhuyet:
                        if (_pmtCauHoiDienKhuyetChum1 != null && _pmtCauHoiDienKhuyetChum1.ValidateNoiDung())
                        {
                            if (UICommon.ShowMsgQuestionString("Bạn muốn lưu câu hỏi hiện tại?") != DialogResult.Yes)
                                return;
                            _pmtCauHoiDienKhuyetChum1.IdMucDoNhanThuc = (int)cboMucDoNhanThuc.CategoryID;
                            _pmtCauHoiDienKhuyetChum1.IdDanhMuc = IdDanhMuc;
                            _pmtCauHoiDienKhuyetChum1.IdLoaiCauHoi = (int)_idLoaiCauHoi;
                            if (Mode == ModeForm.ThemMoi)
                            {
                                if (!_pmtCauHoiDienKhuyetChum1.SaveNewCauHoi())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            else
                            {
                                if (!_pmtCauHoiDienKhuyetChum1.SaveUpdateCauHoi())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            ClearAllData();
                            LoadModulCauHoi();
                            UICommon.ShowMsgUpdateSuccess();
                        }
                        break;

                    #endregion

                    #region Cau hoi đúng sai

                    case LoaiCauHoi.CauHoiDungSai:
                        if (_pmtCauHoiDungSaiDon1 != null && _pmtCauHoiDungSaiDon1.ValidateNoiDung())
                        {
                            if (UICommon.ShowMsgQuestionString("Bạn muốn lưu câu hỏi hiện tại?") != DialogResult.Yes)
                                return;
                            _pmtCauHoiDungSaiDon1.IdMucDoNhanThuc = (int)cboMucDoNhanThuc.CategoryID;
                            _pmtCauHoiDungSaiDon1.IdDanhMuc = IdDanhMuc;
                            _pmtCauHoiDungSaiDon1.IdLoaiCauHoi = (int)_idLoaiCauHoi;
                            if (Mode == ModeForm.ThemMoi)
                            {
                                if (!_pmtCauHoiDungSaiDon1.SaveCauHoiNew())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            else
                            {
                                if (!_pmtCauHoiDungSaiDon1.SaveUpdateCauHoi())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            ClearAllData();
                            LoadModulCauHoi();
                            UICommon.ShowMsgUpdateSuccess();
                        }

                        break;

                    #endregion

                    #region Cau hoi đúng sai nhóm

                    case LoaiCauHoi.CauHoiDungSaiNhom:
                        if (_pmtCauHoiDungSaiChum1 != null && _pmtCauHoiDungSaiChum1.ValidateNoiDung())
                        {
                            if (UICommon.ShowMsgQuestionString("Bạn muốn lưu câu hỏi hiện tại?") != DialogResult.Yes)
                                return;
                            _pmtCauHoiDungSaiChum1.IdMucDoNhanThuc = (int)cboMucDoNhanThuc.CategoryID;
                            _pmtCauHoiDungSaiChum1.IdDanhMuc = IdDanhMuc;
                            _pmtCauHoiDungSaiChum1.IdLoaiCauHoi = (int)_idLoaiCauHoi;
                            if (Mode == ModeForm.ThemMoi)
                            {
                                if (!_pmtCauHoiDungSaiChum1.SaveNewCauHoi())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            else
                            {
                                if (!_pmtCauHoiDungSaiChum1.SaveUpdateCauHoi())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            ClearAllData();
                            LoadModulCauHoi();
                            UICommon.ShowMsgUpdateSuccess();
                        }
                        break;

                    #endregion                    

                    #region Cau hoi nối chéo

                    case LoaiCauHoi.CauHoiNoiCheo:
                        if (_pmtCauHoiNoiCheoDon1 != null && _pmtCauHoiNoiCheoDon1.ValidateNoiDung())
                        {
                            if (UICommon.ShowMsgQuestionString("Bạn muốn lưu câu hỏi hiện tại?") != DialogResult.Yes)
                                return;
                            _pmtCauHoiNoiCheoDon1.IdMucDoNhanThuc = (int)cboMucDoNhanThuc.CategoryID;
                            _pmtCauHoiNoiCheoDon1.IdDanhMuc = IdDanhMuc;
                            _pmtCauHoiNoiCheoDon1.IdLoaiCauHoi = (int)_idLoaiCauHoi;
                            if (Mode == ModeForm.ThemMoi)
                            {
                                if (!_pmtCauHoiNoiCheoDon1.SaveCauHoiNew())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            else
                            {
                                if (!_pmtCauHoiNoiCheoDon1.SaveUpdateCauHoi())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            ClearAllData();
                            LoadModulCauHoi();
                            UICommon.ShowMsgUpdateSuccess();
                        }
                        break;

                    #endregion

                    #region Cau hoi sắp xếp

                    case LoaiCauHoi.CauHoiSapXepDoanVan:
                        if (_pmtCauHoiSapXep != null && _pmtCauHoiSapXep.ValidateNoiDung())
                        {
                            if (UICommon.ShowMsgQuestionString("Bạn muốn lưu câu hỏi hiện tại?") != DialogResult.Yes)
                                return;
                            _pmtCauHoiSapXep.IdMucDoNhanThuc = (int)cboMucDoNhanThuc.CategoryID;
                            _pmtCauHoiSapXep.IdDanhMuc = IdDanhMuc;
                            _pmtCauHoiSapXep.IdLoaiCauHoi = (int)_idLoaiCauHoi;
                            if (Mode == ModeForm.ThemMoi)
                            {
                                if (_pmtCauHoiSapXep.SaveCauHoiNew() == 0)
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            else
                            {
                                if (_pmtCauHoiSapXep.SaveUpdateCauHoi() == 0)
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            ClearAllData();
                            LoadModulCauHoi();
                            UICommon.ShowMsgUpdateSuccess();
                        }
                        break;

                    #endregion

                    #region Cau hoi hoàn thành câu

                    case LoaiCauHoi.CauHoiHoanThanhCau:
                        if (_pmtCauHoiHoanThanhCau != null && _pmtCauHoiHoanThanhCau.ValidateNoiDung())
                        {
                            if (UICommon.ShowMsgQuestionString("Bạn muốn lưu câu hỏi hiện tại?") != DialogResult.Yes)
                                return;
                            _pmtCauHoiHoanThanhCau.IdMucDoNhanThuc = (int)cboMucDoNhanThuc.CategoryID;
                            _pmtCauHoiHoanThanhCau.IdDanhMuc = IdDanhMuc;
                            _pmtCauHoiHoanThanhCau.IdLoaiCauHoi = (int)_idLoaiCauHoi;
                            if (Mode == ModeForm.ThemMoi)
                            {
                                if (_pmtCauHoiHoanThanhCau.SaveCauHoiNew() == 0)
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            else
                            {
                                if (_pmtCauHoiHoanThanhCau.SaveUpdateCauHoi() == 0)
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            ClearAllData();
                            LoadModulCauHoi();
                            UICommon.ShowMsgUpdateSuccess();
                        }
                        break;

                    #endregion

                    #region Cau hoi tu luan

                    case LoaiCauHoi.CauHoiTuLuan:
                        if (_pmtCauHoiTuluanDon1 != null && _pmtCauHoiTuluanDon1.ValidateNoiDung())
                        {
                            if (UICommon.ShowMsgQuestionString("Bạn muốn lưu câu hỏi hiện tại?") != DialogResult.Yes)
                                return;
                            _pmtCauHoiTuluanDon1.IdMucDoNhanThuc = (int)cboMucDoNhanThuc.CategoryID;
                            _pmtCauHoiTuluanDon1.IdDanhMuc = IdDanhMuc;
                            _pmtCauHoiTuluanDon1.IdLoaiCauHoi = (int)_idLoaiCauHoi;
                            if (Mode == ModeForm.ThemMoi)
                            {
                                if (!_pmtCauHoiTuluanDon1.SaveNewCauHoi())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            else
                            {
                                if (!_pmtCauHoiTuluanDon1.SaveUpdateCauHoi())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            ClearAllData();
                            LoadModulCauHoi();
                            UICommon.ShowMsgUpdateSuccess();
                        }
                        break;

                    #endregion

                    #region Tu luan nhom

                    case LoaiCauHoi.CauHoiTuLuanNhom:
                        if (_pmtCauHoiTuluanChum1 != null && _pmtCauHoiTuluanChum1.ValidateNoiDung())
                        {
                            if (UICommon.ShowMsgQuestionString("Bạn muốn lưu câu hỏi hiện tại?") != DialogResult.Yes)
                                return;
                            _pmtCauHoiTuluanChum1.IdMucDoNhanThuc = (int)cboMucDoNhanThuc.CategoryID;
                            _pmtCauHoiTuluanChum1.IdDanhMuc = IdDanhMuc;
                            _pmtCauHoiTuluanChum1.IdLoaiCauHoi = (int)_idLoaiCauHoi;
                            if (Mode == ModeForm.ThemMoi)
                            {
                                if (!_pmtCauHoiTuluanChum1.SaveNewCauHoi())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            else
                            {
                                if (!_pmtCauHoiTuluanChum1.SaveUpdateCauHoi())
                                {
                                    UICommon.ShowMsgSplashPanelUnComplete();
                                    return;
                                }
                            }
                            ClearAllData();
                            LoadModulCauHoi();
                            UICommon.ShowMsgUpdateSuccess();
                        }
                        break;

                        #endregion
                }
            }
        }

        #endregion

        #endregion

        #region Protected

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            #region Control

            if (Mode == ModeForm.CapNhat)
            {
                LoadDataControl();
                cboLoaiCauHoi.Enabled = false;
            }
            else
            {
                cboLoaiCauHoi.CategoryID = 1;
                SetFocusNode(_idDanhMuc ?? 0);
                var selected_node = treeList1.FindNodeByFieldValue("Id", _idDanhMuc);
                if (selected_node != null) _currentNode = treeList1.GetDataRecordByNode(selected_node) as EX_DanhMuc;
                AddNewCauHoi(false);
            }

            #endregion
        }

        #endregion

        #region Event

        #region Treelist

        private void TreeList1_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            foreach (DXMenuItem item in e.Menu.Items)
            {
                string caption = TreeListLocalizer.Active.GetLocalizedString(TreeListStringId.MenuColumnColumnCustomization);
                if (item.Caption == caption)
                {
                    item.Visible = false;
                }
            }
        }

        private void TreeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            _currentNode = treeList1.GetDataRecordByNode(e.Node) as EX_DanhMuc;
        }

        private void TreeList1_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            switch (e.Node.Level)
            {
                case 0:
                    e.NodeImageIndex = 0;
                    break;
                case 1:
                    e.NodeImageIndex = 1;
                    break;
                case 2:
                    e.NodeImageIndex = 2;
                    break;
                case 3:
                    e.NodeImageIndex = 3;
                    break;
                case 4:
                    e.NodeImageIndex = 4;
                    break;
                default:
                    e.NodeImageIndex = 5;
                    break;
            }
        }

        private void TreeList1_CustomColumnSort(object sender, DevExpress.XtraTreeList.CustomColumnSortEventArgs e)
        {
            if (e.Column.FieldName == "TenDanhMuc")
            {
                object val1 = e.Node1["STT"];
                object val2 = e.Node2["STT"];
                e.Result = Comparer.Default.Compare(val1, val2);
            }
        }

        #endregion

        #region Tsb        

        private void TsbCapture_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            if (_frmct != null)
            {
                _frmct.Dispose();
            }
            _frmct = new CaptureCT();
            _frmct.OnCaptureEvent += ct_OnCaptureEvent;
            _frmct.StartPosition = FormStartPosition.CenterScreen;
            _frmct.Show();
        }

        private void TsbMath_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            OpenFileFormula();
        }

        private void TsbInsertSymbol_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            if (_currentTextControl != null)
            {
                FormulerButton(PointToClient(MousePosition));
            }
        }

        private void TsbInsertImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            if (_currentTextControl != null)
            {
                _currentTextControl.InsertImage();
            }
        }

        private void TsbBackcolor_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            if (_currentTextControl != null)
            {
                Color color = _currentTextControl.EditorBackColor;
                using (ColorDialog dlg = new ColorDialog())
                {
                    dlg.SolidColorOnly = true;
                    dlg.AllowFullOpen = false;
                    dlg.AnyColor = false;
                    dlg.FullOpen = false;
                    dlg.CustomColors = null;
                    dlg.Color = color;
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        color = dlg.Color;
                        _currentTextControl.EditorBackColor = color;
                    }
                }
            }
        }

        private void TsbForeColor_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            if (_currentTextControl != null)
            {
                Color color = _currentTextControl.EditorForeColor;
                using (ColorDialog dlg = new ColorDialog())
                {
                    dlg.SolidColorOnly = true;
                    dlg.AllowFullOpen = false;
                    dlg.AnyColor = false;
                    dlg.FullOpen = false;
                    dlg.CustomColors = null;
                    dlg.Color = color;
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        color = dlg.Color;
                        _currentTextControl.EditorForeColor = color;
                    }
                }
            }
        }

        private void TsbFont_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            if (_currentTextControl != null)
            {
                Font font = _currentTextControl.EditorFont;
                using (FontDialog dlg = new FontDialog())
                {
                    dlg.Font = font;
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        font = dlg.Font;
                        _currentTextControl.EditorFont = font;
                    }
                }
            }
        }

        private void TsbRight_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            if (_currentTextControl != null)
            {
                _currentTextControl.JustifyRight();
            }
        }

        private void TsbCenter_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            if (_currentTextControl != null)
            {
                _currentTextControl.JustifyCenter();
            }
        }

        private void TsbLeft_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            if (_currentTextControl != null)
            {
                _currentTextControl.JustifyLeft();
            }
        }

        private void TsbUnderline_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            _currentTextControl?.Underline();
            SimpleTest.Common.EventAggregator.Instance.Publish(_currentTextControl, Common.EventType.UnderlineClick, null);
        }

        private void TsbItalic_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            if (_currentTextControl != null)
            {
                _currentTextControl.Italic();
            }
        }

        private void TsbBold_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            if (_currentTextControl != null)
            {
                _currentTextControl.Bold();
            }
        }

        private void TsbDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            _currentTextControl.SelectedText = "";
        }

        private void TsbPaste_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            _currentTextControl.Paste(DataFormats.GetFormat("Text"));
        }

        private void TsbCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            _currentTextControl.Copy();
        }

        private void TsbCut_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentTextControl = _currentUserControl.CurrentControl;
            _currentTextControl.Cut();
        }

        private void TsbClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void TsbSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveCauHoi();
        }

        private void TsbAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddNewCauHoi(true);
        }

        #endregion

        #region Event Control

        private void ct_OnCaptureEvent(bool capture)
        {
            if (capture)
            {
                if (_currentTextControl != null)
                {
                    _currentTextControl.InsertImageClipboard();
                }
                if (_frmct != null)
                    _frmct.Close();
            }
        }

        private void frm_OnSelectedSymbol()
        {
            _currentTextControl.Paste();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (_currentTextControl != null)
            {
                //Set all the style buttons using the gathered style
                tsbBold.Appearance.BackColor = _currentTextControl.IsBold() ? Color.FromArgb(114, 126, 144, 173) : tsbAdd.Appearance.BackColor;
                tsbItalic.Appearance.BackColor = _currentTextControl.IsItalic() ? Color.FromArgb(114, 126, 144, 173) : tsbAdd.Appearance.BackColor;
                tsbUnderline.Appearance.BackColor = _currentTextControl.IsUnderline() ? Color.FromArgb(114, 126, 144, 173) : tsbAdd.Appearance.BackColor;
                tsbLeft.Appearance.BackColor = _currentTextControl.IsJustifyLeft() ? Color.FromArgb(114, 126, 144, 173) : tsbAdd.Appearance.BackColor; //justify left
                tsbCenter.Appearance.BackColor = _currentTextControl.IsJustifyCenter() ? Color.FromArgb(114, 126, 144, 173) : tsbAdd.Appearance.BackColor;//justify center
                tsbRight.Appearance.BackColor = _currentTextControl.IsJustifyRight() ? Color.FromArgb(114, 126, 144, 173) : tsbAdd.Appearance.BackColor; //justify right
            }
        }

        #endregion

        #endregion

        #region Properties

        public long IdCauHoi { get => _idCauHoi; set => _idCauHoi = value; }
        public long IdCauHoiCha { get => _idCauHoiCha; set => _idCauHoiCha = value; }
        public bool IsCauHoiCha { get => _isCauHoiCha; set => _isCauHoiCha = value; }
        public ModeForm Mode { get => _mode; set => _mode = value; }
        public EX_CauHoi CurentCauHoi { get => _curentCauHoi; set => _curentCauHoi = value; }
        public long? IdDanhMuc { get => _idDanhMuc; set => _idDanhMuc = value; }

        #endregion
    }
}