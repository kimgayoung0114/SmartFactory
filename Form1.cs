using Infragistics.Win.UltraWinGrid;
using MultiColoredModernUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiColoredModernUI
{
    public partial class FormMainMenu : Form
    {
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        //Constructor
        public FormMainMenu()
        {
            InitializeComponent();
            random = new Random();
            btnClose.Visible = true;
            this.Text = string.Empty;
            this.ControlBox = false;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Methods
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

        private void ActivateButton(object btnSender)
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
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                    btnToolBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnClose.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                }
            }
        }

        private void DoFormVisible()
        {
            if (panelDesktop.Controls.Count != 0)
            {
                for (int i = 0; i < panelDesktop.Controls.Count; i++)
                {
                    panelDesktop.Controls[i].Visible = false;
                }
                panelDesktop.Controls[0].Visible = false;
            }
        }

        #region < 설비 정보 >
        private void btnProducts_Click(object sender, EventArgs e)
        {
            DoFormVisible();
            FormProduct im = new FormProduct();
            im.TopLevel = false;
            panelDesktop.Controls.Add(im);
            im.Show();
        }
        #endregion

        #region < 작업자 마스터 >
        private void btnWorking_Click_1(object sender, EventArgs e)
        {
            DoFormVisible();
            FormWokrMaster im1 = new FormWokrMaster();
            im1.TopLevel = false;
            panelDesktop.Controls.Add(im1);
            im1.Show();
        }
        #endregion

        #region < 설비운영현황 >
        private void btnNow_Click_1(object sender, EventArgs e)
        {
            DoFormVisible();
            FormNow im2 = new FormNow();
            im2.TopLevel = false;
            panelDesktop.Controls.Add(im2);
            im2.Show();
        }
        #endregion

        #region < 알람 >
        private void btnNotifications_Click_1(object sender, EventArgs e)
        {
            DoFormVisible();
            FormNotifications im3 = new FormNotifications();
            im3.TopLevel = false;
            panelDesktop.Controls.Add(im3);
            im3.Show();
        }
        #endregion

        #region < 대시보드 >
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            DoFormVisible();
            FormDashboard im4 = new FormDashboard();
            im4.TopLevel = false;
            panelDesktop.Controls.Add(im4);
            im4.Show();
        }
        #endregion


        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void FormMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Result = MessageBox.Show("프로그램을 종료 하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo);
            if (Result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnToolBar_Click(object sender, EventArgs ea)
        {
            // 버튼 종류 구분
            ToolStripButton tsb = sender as ToolStripButton;

            if (panelDesktop.Controls.Count == 0) return;
            IToolBar toolbarMenu = panelDesktop.Controls[0] as IToolBar;

            //panel bch = panelDesktop.Select;

            //foreach (Control control in panelDesktop.Controls)
            //{
            //    if (control is basechildform basechildform)
            //    {
            //        bch = basechildform;
            //        break;
            //    }
            //}

            switch (tsb.Tag.ToString())
            {
                case "SEARCH":
                    toolbarMenu.DoInquire();
                    break;
                case "ADD":
                    toolbarMenu.DoNew();
                    break;
                case "SAVE":
                    toolbarMenu.DoSave();
                    break;
                case "DELETE":
                    toolbarMenu.DoDelete();
                    break;
            }
        }
    }
}

