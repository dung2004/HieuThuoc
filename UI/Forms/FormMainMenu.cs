using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using HieuThuoc.Common;
using HieuThuoc.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;

namespace HieuThuoc.UI.Forms
{
    public partial class FormMainMenu : Form
    {
        private const string ImageFolder =
            @"D:\\Document\\University\\Subject\\Year4\\Semester1\\C#\\Project\\HieuThuoc\\Resources\\ImageFile\\";

        private const string DefaultImageFile = "null.jpg";

        //fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activateForm;
        private bool isClick = true;

        //constructor
        public FormMainMenu()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            customDe();
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            UpdateAuthButtons();
            var roleId = CurrentUser.RoleId;

            //gọi presenter load data và cảnh báo
            // _presenter.LoadDashboardData(roleId);
            // _presenter.LoadExpiryAlerts();
            ApplyRoleMask(roleId);
        }

        private void UpdateAuthButtons()
        {
            if (CurrentUser.IsAuthenticated)
            {
                btnLogout.Visible = true;
                UpdateLoginButtonState();
                LoadCurrentUserImageToPb();
                if (labelUserName != null) labelUserName.Text = CurrentUser.FullName;
            }
            else
            {
                btnLogout.Visible = false;
                btnLogin.Text = "  Staff Login";
                if (pbImage != null) pbImage.Image = null;
                if (labelUserName != null) labelUserName.Text = string.Empty;
            }
        }

        public void UpdateLoginButtonState()
        {
            if (btnLogin == null) return;
            if (CurrentUser.IsAuthenticated && CurrentUser.RoleId == 1)
            {
                btnLogin.Text = "  Create User";
            }
            else
            {
                btnLogin.Visible = false;
            }

            btnLogout.Visible = CurrentUser.IsAuthenticated;
            LoadCurrentUserImageToPb();
            if (labelUserName != null)
            {
                labelUserName.Text = CurrentUser.IsAuthenticated ? CurrentUser.FullName : string.Empty;
            }
        }

        private void LoadCurrentUserImageToPb()
        {
            if (pbImage == null || !CurrentUser.IsAuthenticated) return;
            try
            {
                var repo =
                    HieuThuoc.UI.Program.ServiceProvider.GetService(typeof(IAccountRepository)) as IAccountRepository;
                var acc = repo?.GetById(CurrentUser.AccId);
                var fileName = acc?.ImageFile;
                string fullPath = null;
                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    var maybe = Path.Combine(ImageFolder, fileName);
                    if (File.Exists(maybe)) fullPath = maybe;
                }

                // fallback: null.jpg
                if (fullPath == null)
                {
                    var def = Path.Combine(ImageFolder, DefaultImageFile);
                    if (File.Exists(def)) fullPath = def;
                }

                if (fullPath != null)
                {
                    using (var img = Image.FromFile(fullPath))
                    {
                        pbImage.Image = new Bitmap(img);
                    }

                    pbImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pbImage.Image = null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load image error: " + ex.Message);
                pbImage.Image = null;
            }
        }

        public void ApplyRoleMask(int roleId)
        {
            // 1=Admin, 2=QuanLy, 3=NhanVien, 0=guest
            bool isAdmin = roleId == 1;
            bool isManager = roleId == 2;
            bool isStaff = roleId == 3;
            bool isGuest = roleId == 0;

            //Nút hiển thị Management menu chỉ cho Manager/Admin
            buttonManagement.Visible = isManager || isAdmin || isStaff;

            // Cho phép tất cả xem dashboard, còn các nút khác ẩn/hiện theo role
            btnUserMana.Visible = isAdmin; // chỉ admin

            // CRUD trên các form quản lý: Manager/Admin được, Staff chỉ read-only (form xử lý bên trong)
            btnDashBoard.Visible = isManager || isAdmin || isStaff;
            btnPurchase.Visible = isManager || isAdmin || isStaff;
            btnPackagingMana.Visible = isManager || isAdmin;
            btnSupplierMana.Visible = isManager || isAdmin;
            btnBatchMana.Visible = isManager || isAdmin ; 
            btnMedicineMana.Visible = isManager || isAdmin ;
            btnSale.Visible = isStaff || isManager || isAdmin;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender, bool showCloseChildForm = true)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = showCloseChildForm;
                }
            }
        }
        private void DisableButton()
        {
            ResetButtonColors(panelMenu);
        }
        private void ResetButtonColors(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(51, 51, 76);
                    btn.ForeColor = Color.Gainsboro;
                    btn.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular,
                                        GraphicsUnit.Point, ((byte)(0)));
                }
                else if (ctrl.HasChildren)
                {
                    ResetButtonColors(ctrl);
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activateForm != null) activateForm.Close();

            ActivateButton(btnSender);
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void customDe()
        {
            panelManagement.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelManagement.Visible == true)
                panelManagement.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Xác nhận
            var confirm = MessageBox.Show("Bạn chắc chắn muốn đăng xuất?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            // Clear current user
            CurrentUser.Clear();

            // Đóng child form hiện tại nếu có
            if (activateForm != null)
            {
                activateForm.Close();
                activateForm = null;
            }

            // Reset UI
            Reset();
            // Sau khi logout: áp role guest và cập nhật nút
            ApplyRoleMask(0);
            UpdateAuthButtons();
            btnLogin.Visible = true;
            if (pbImage != null) pbImage.Image = null;
            if (labelUserName != null) labelUserName.Text = string.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Nếu chưa đăng nhập => mở form login
            if (!CurrentUser.IsAuthenticated)
            {
                var loginForm = HieuThuoc.UI.Program.ServiceProvider.GetService(typeof(FormLogin)) as FormLogin;
                if (loginForm == null)
                {
                    MessageBox.Show("Không tạo được FormLogin từ DI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                OpenChildForm(loginForm, sender);
            }
            else
            {
                // Chỉ Admin mới được vào Create User
                if (CurrentUser.RoleId == 1)
                {
                    OpenChildForm(new Forms.FormCreateUser(), sender);
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền tạo người dùng.", "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activateForm != null)
            {
                activateForm.Close();
            }
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Home";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnBatchMana_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormBatchManagement(), sender);
        }

        private void btnSupplierMana_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSupplierManagement(), sender);
        }

        private void btnPackagingMana_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormPackagingManagement(), sender);
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormPurchase(), sender);
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSale(), sender);
        }

        private void btnMedicineMana_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormMedicineManagement(), sender);
        }

        private void btnUserMana_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormUserManagement(), sender);
        }

        private void buttonManagement_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, false);
            if (isClick)
            {
                showSubMenu(panelManagement);
                isClick = false;
            }
            else
            {
                hideSubMenu();
                isClick = true;
            }
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDashBoard(), sender);
        }
    }
}
