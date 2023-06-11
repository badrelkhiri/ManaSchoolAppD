using CustomAlertBoxDemo;
using Gestion_de_l_école.ColorClass;
using SchoolManagment3.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagment3.PL
{
    public partial class FAjouterFrais : Form
    {
        public FAjouterFrais()
        {
            InitializeComponent();
            GetData();
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void GetData()
        {
            DataTable dt = Class_OtherFees.usp_tblOtherFeesSelect();
            grdView.DataSource = dt;
            grdView.Columns[0].Visible = false;
        }

        private void Clean()
        {
            foreach (Control c in groupBox2.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }
        private void nButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                   (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void grdView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = grdView.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = grdView.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = grdView.CurrentRow.Cells[2].Value.ToString();
        }

        private void nButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void nButton3_Click(object sender, EventArgs e)
        {
        
        }

        private void nButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    this.Alert("Double-cliquez sur le dessin pour sélectionner l'ID", Form_Alert.enmType.Warning);
                    return;
                }
                DialogResult dr = MessageBox.Show("Voulez-vous vraiment supprimer ce dessin", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_OtherFees.usp_tblOtherFeesDelete(int.Parse(txtID.Text));
                    this.Alert("Supprimé avec succès", Form_Alert.enmType.Success);
                    GetData();
                    Clean();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void nButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    this.Alert("Double-cliquez sur le dessin pour sélectionner l'ID", Form_Alert.enmType.Warning);
                    return;
                }
                Class_OtherFees.usp_tblOtherFeesUpdate(int.Parse(txtID.Text), txtName.Text, decimal.Parse(txtPrice.Text));
                this.Alert("Modifié avec succès", Form_Alert.enmType.Success);
                GetData();
                Clean();
            }
            catch
            {
                MessageBox.Show("Incorrect symbol ','");
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtPrice.Text == "")
                {
                    this.Alert("Veuillez vérifier les champs", Form_Alert.enmType.Warning);
                    return;
                }
                Class_OtherFees.usp_tblOtherFeesInsert(txtName.Text, decimal.Parse(txtPrice.Text));
                this.Alert("Frais ajoutés avec succès", Form_Alert.enmType.Success);
                GetData();
                Clean();
            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627)
                {
                    this.Alert("cette Frais existe déjà", Form_Alert.enmType.Success);
                }
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void nButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(NouveauButtons.NButton))
                {
                    NouveauButtons.NButton btn = (NouveauButtons.NButton)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }
        private void FAjouterFrais_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
