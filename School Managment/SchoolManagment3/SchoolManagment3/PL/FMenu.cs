using SchoolManagment3;
using SchoolManagment3.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_l_école
{
    public partial class FMenu : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public static bool check = false;
        public static string username;

        public FMenu()
        {
            InitializeComponent();
            random = new Random();
            btnClose.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private Color SelectThemeColor()
        {
            int index = random.Next(ColorClass.ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ColorClass.ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ColorClass.ThemeColor.ColorList[index];
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
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitreBar.BackColor = color;
                    panelLogo.BackColor = ColorClass.ThemeColor.ChangeColorBrightness(color, -0.3);
                    ColorClass.ThemeColor.PrimaryColor = color;
                    ColorClass.ThemeColor.SecondaryColor = ColorClass.ThemeColor.ChangeColorBrightness(color, -0.3);
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
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelBureau.Controls.Add(childForm);
            this.panelBureau.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitre.Text = childForm.Text;
        }

        private void FMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnE_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FAjouterEtudinat(false), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FGestionDesEtudiant("New"), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FGestionAnneesScolaire(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FGestionFiliere(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FGestionDesClasses(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FGestionRemise(), sender);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lblTitre.Text = "HOME";
            panelTitreBar.BackColor = Color.FromArgb(51, 51, 76);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnClose.Visible = false;
        }

        private void FMenu_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panelTitreBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAgrandir_Click(object sender, EventArgs e)
        {
            //if (WindowState == FormWindowState.Normal)
            //    this.WindowState = FormWindowState.Maximized;
            //else
            //    this.WindowState = FormWindowState.Normal;
        }

        private void BtnReduir_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblTitre_Click(object sender, EventArgs e)
        {

        }

        private void panelBureau_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTitreBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FAjouterPaiement(), sender);


        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FGestionPaiement(), sender);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FStatistiquesDePaiement(), sender);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FRetardDePaiement(), sender);

        }

        private void button10_Click(object sender, EventArgs e)
        {

            OpenChildForm(new FAjouterNouvUtilisateur(), sender);

        }
    }
}
