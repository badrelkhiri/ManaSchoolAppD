using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using Gestion_de_l_école;
using CustomAlertBoxDemo;
using SchoolManagment3.BL;

namespace gestion_biblio
{
    public partial class FConnexion : Form
    {
        public FConnexion()
        {
            InitializeComponent();
        }

        private void txtuser_MouseEnter(object sender, EventArgs e)
        {
            if (txtuser.Text == "Entrer votre Nom")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_MouseLeave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Entrer votre Nom";
                txtuser.ForeColor = Color.Silver;
            }
        }

        private void txtpass_MouseEnter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Entrer votre mot de passe")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_MouseLeave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Entrer votre mot de passe";
                txtpass.ForeColor = Color.Silver;
                txtpass.UseSystemPasswordChar = false;
            }
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void FConnexion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {
            //if (txtuser.Text == "Entrer votre Email")
            //{
            //    txtuser.Text = "";

            //}
        }

        private void FConnexion_Load(object sender, EventArgs e)
        {

        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtuser.Text == "" || txtpass.Text == "")
                {
                    this.Alert("Tous les champs sont obligatoires", Form_Alert.enmType.Warning);
                    return;
                }
                DataTable dt = Class_login.usp_login(txtuser.Text, txtpass.Text);
                if (dt.Rows.Count == 1)
                {
                    FMenu.username = txtuser.Text;
                    this.Hide();
                    FMenu f = new FMenu();
                    f.Show();
                }
                else
                {
                    this.Alert("Nom d'utilisateur ou mot de passe erroné", Form_Alert.enmType.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
