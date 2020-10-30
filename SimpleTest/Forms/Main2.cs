using DataLayer.BLL;
using DataLayer.DAL;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using SimpleTest.Forms;
using SimpleTest.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SimpleTest
{
    public partial class Main2 : DevExpress.XtraBars.Ribbon.RibbonForm, IDocumentsHostWindow
    {
        #region Variable

        private MenuBll _bus = new MenuBll();

        private List<HT_Page> _lstPage = new List<HT_Page>();
        private List<HT_Group> _lstGroup = new List<HT_Group>();
        private List<HT_Form> _lstForm = new List<HT_Form>();
        private Dictionary<int, List<HT_Form>> _dicButtonContain = new Dictionary<int, List<HT_Form>>();
        private static List<string> _lstModule = new List<string>();

        public DocumentManager DocumentManager
        {
            get
            {
                return documentManager1;
            }
        }

        public bool DestroyOnRemovingChildren
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region Constructor

        public Main2()
        {
            InitializeComponent();
            _lstPage = _bus.GetAllPage();
            _lstGroup = _bus.GetAllGroup();
            _lstForm = _bus.GetAllForm();

            InitForm();
        }

        #endregion

        #region Private

        private void InitForm()
        {
            tabbedView.DocumentProperties.AllowPin = true;
            tabbedView.FloatingDocumentContainer = DevExpress.XtraBars.Docking2010.Views.FloatingDocumentContainer.DocumentsHost;
            tabbedView.CustomDocumentsHostWindow += tabbedView1_CustomDocumentsHostWindow;
            tabbedView.DocumentActivated += TabbedView_DocumentActivated;
            tabbedView.DocumentClosing += TabbedView_DocumentClosing;
            tabbedView.DocumentClosed += TabbedView_DocumentClosed;
            CreatePage();

        }

        private void CreatePage()
        {
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.Add(ribbonControl1.ExpandCollapseItem);

            foreach (var page in _lstPage.OrderBy(m => m.STT))
            {
                // Tạo Page
                RibbonPage rbpPage = new RibbonPage();
                rbpPage.Name = page.MaPage;
                rbpPage.Text = page.TenPage;
                rbpPage.Visible = page.IsVisible ?? false;

                // Group
                var lstGroup = _lstGroup.Where(m => m.IDPage == page.Id).OrderBy(m => m.STT);
                foreach (var gr in lstGroup)
                {
                    RibbonPageGroup group = new RibbonPageGroup();
                    group.Name = gr.MaGroup;
                    group.Text = gr.TenGroup;

                    // List userControl
                    var lstForm = _lstForm.Where(m => m.IDGroup == gr.Id).OrderBy(m => m.STT);

                    foreach (var frm in lstForm)
                    {
                        BarButtonItem buttonItem = new BarButtonItem();
                        // Manually add the created item to the item collection of the RibbonControl. 
                        ribbonControl1.Items.Add(buttonItem);
                        buttonItem.Caption = frm.TenForm;
                        buttonItem.Id = (int)frm.Id;
                        buttonItem.Name = frm.MaForm;
                        buttonItem.Tag = frm;
                        SetImage(buttonItem, frm.Image);
                        buttonItem.ItemClick += new ItemClickEventHandler(ButtonItem_ItemClick);
                        group.ItemLinks.Add(buttonItem);
                    }

                    rbpPage.Groups.Add(group);
                }

                ribbonControl1.Pages.Add(rbpPage);
            }
        }

        private static Type GetFormType(string formName)
        {
            Type type = null;

            #region Ưu tiên nạp assembly từ project hiện tại

            if (type == null)
            {
                type = GetFormType(string.Empty, formName);
            }

            #endregion

            #region Nạp assembly từ project SimpleTest

            if (type == null)
            {
                type = GetFormType("SimpleTest", formName);
            }

            #endregion

            return type;
        }

        private static Type GetFormType(string assemblyName, string formName)
        {
            Type type = null;
            Assembly assembly = null;

            try
            {
                if (string.IsNullOrEmpty(assemblyName))
                {
                    assembly = Assembly.GetEntryAssembly();

                    // EntryAssembly always not null
                    type = assembly.GetType(assembly.GetName().Name + "." + formName);

                    if (type == null)
                    {
                        type = assembly.GetType(assembly.GetName().Name + ".Forms." + formName);
                    }
                }

                if (type == null)
                {
                    if (File.Exists(GetFullPathFile(string.Format("{0}.dll", assemblyName))) ||
                        File.Exists(GetFullPathFile(string.Format("{0}.exe", assemblyName))))
                    {
                        assembly = Assembly.Load(assemblyName);

                        type = assembly.GetType(assembly.GetName().Name + "." + formName);

                        if (type == null)
                        {
                            type = assembly.GetType(assembly.GetName().Name + ".Forms." + formName);
                        }
                    }

                    if (type == null)
                    {
                        foreach (string item in _lstModule)
                        {
                            if (File.Exists(GetFullPathFile(string.Format("{0}.{1}.dll", assemblyName, item))) ||
                                File.Exists(GetFullPathFile(string.Format("{0}.{1}.exe", assemblyName, item))))
                            {
                                assembly = Assembly.Load(new AssemblyName(string.Format("{0}.{1}", assemblyName, item)));

                                type = assembly.GetType(assembly.GetName().Name + ".Forms." + formName);

                                if (type != null)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e) { }

            return type;
        }

        public static string GetFullPathFile(string fileName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }

        public void SetImage(BarButtonItem toolStripItem, string imageName)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                try
                {
                    toolStripItem.ImageOptions.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName + "_16");
                    toolStripItem.ImageOptions.LargeImage = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
                }
                catch (Exception)
                {
                }
            }
        }

        private void LoadForm(HT_Form tag)
        {
            bool exists = false;
            int i = 0;
            for (; i < tabbedView.Documents.Count; i++)
            {
                if (tabbedView.Documents[i].Control.Name == tag.MaForm)
                {
                    exists = true;
                    break;
                }
            }

            // kiem tra de focus hoac add form
            if (tag.IsShowDialog ?? false)
            {
                var type = GetFormType(tag.MaForm);
                if (type == null) return;
                try
                {
                    var frm = (FormBase)Activator.CreateInstance(type);
                    if (frm != null)
                    {
                        frm.Tag = tag;
                        frm.Text = tag.TenForm;
                        frm.ShowDialog();
                        frm.Dispose();
                    }
                }
                catch (Exception)
                {
                    var frm = (DevExpress.XtraBars.Ribbon.RibbonForm)Activator.CreateInstance(type);
                    if (frm != null)
                    {
                        frm.Tag = tag;
                        frm.Text = tag.TenForm;
                        frm.ShowDialog();
                        frm.Dispose();
                    }
                }
            }
            else
            {
                if (exists)
                {
                    tabbedView.ActivateDocument(tabbedView.Documents[i].Control);
                }
                else
                {
                    var type = GetFormType(tag.MaForm);
                    if (type == null) return;
                    var frm = (FormBase)Activator.CreateInstance(type);
                    if (frm != null)
                    {
                        frm.Tag = tag;
                        frm.Text = tag.TenForm;
                        tabbedView.AddDocument(frm);
                        tabbedView.ActivateDocument(frm);
                    }
                }
            }

        }

        private void CloseForm(FormBase frm)
        {
            if (frm != null)
            {
                var tag = (HT_Form)frm.Tag;
                if (tag != null)
                {
                    var group = _lstGroup.FirstOrDefault(m => m.Id == tag.IDGroup);
                    var page = _lstPage.FirstOrDefault(m => m.Id == group.IDPage);
                    var pageInRibbon = ribbonControl1.Pages.FirstOrDefault(m => m.Name == page.MaPage);
                    if (pageInRibbon != null)
                    {
                        var groupExists = pageInRibbon.Groups.FirstOrDefault(m => m.Name == "rbgCn");
                        if (groupExists != null)
                        {
                            pageInRibbon.Groups.Remove(groupExists);
                        }
                    }
                }
            }
        }

        #endregion

        #region Event

        private void ButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            var tag = (HT_Form)e.Item.Tag;
            LoadForm(tag);
            SplashScreenManager.CloseForm(false);
        }

        private void tabbedView1_CustomDocumentsHostWindow(object sender, CustomDocumentsHostWindowEventArgs e)
        {
            e.Constructor = () => { return new Main2(); };
        }

        private void TabbedView_DocumentActivated(object sender, DocumentEventArgs e)
        {
            var frm = (FormBase)e.Document.Form;
            if (frm != null)
            {
                var tag = (HT_Form)frm.Tag;
                if (tag != null)
                {
                    var group = _lstGroup.FirstOrDefault(m => m.Id == tag.IDGroup);
                    var page = _lstPage.FirstOrDefault(m => m.Id == group.IDPage);
                    var pageInRibbon = ribbonControl1.Pages.FirstOrDefault(m => m.Name == page.MaPage);
                    if (pageInRibbon != null)
                    {
                        ribbonControl1.SelectedPage = pageInRibbon;
                        var groupExists = pageInRibbon.Groups.FirstOrDefault(m => m.Name == "rbgCn");
                        if (groupExists != null)
                        {
                            pageInRibbon.Groups.Remove(groupExists);
                        }
                        frm.Group.Text = string.Format("Chức năng {0}", frm.Text);
                        pageInRibbon.Groups.Add(frm.Group);
                    }
                }
            }
        }

        private void TabbedView_DocumentClosing(object sender, DocumentCancelEventArgs e)
        {
            var frm = (FormBase)e.Document.Form;
            CloseForm(frm);
        }

        private void TabbedView_DocumentClosed(object sender, DocumentEventArgs e)
        {
            var frm = (FormBase)e.Document.Form;
            CloseForm(frm);
        }

        #endregion
    }
}
