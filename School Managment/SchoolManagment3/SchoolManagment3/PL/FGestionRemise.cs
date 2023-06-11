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
    public partial class FGestionRemise : Form
    {
        public FGestionRemise()
        {
            InitializeComponent();
            GetData();
        }
        private void GetData()
        {
            DataTable dt = Class_Discount.usp_tblDiscountSelect();
            grdView.DataSource = dt;
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void Clean()
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            foreach (Control c in groupBox2.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new FGestionDesEtudiant("Discount").ShowDialog();
            txtNum.Text = FGestionDesEtudiant.ID;
            txtName.Text = FGestionDesEtudiant.SName;
        }

        private void nButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNum.Text == "" || txtPrice.Text == "")
                {
                    this.Alert("Veuillez vérifier les champs", Form_Alert.enmType.Info);
                    return;
                }
                Class_Discount.usp_tblDiscountInsert(decimal.Parse(txtPrice.Text), txtDesc.Text, txtNum.Text);
                this.Alert("Réduction ajoutée avec succès", Form_Alert.enmType.Success);
                GetData();
                Clean();
            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627)
                {
                    this.Alert("Cet étudiant a déjà fait une réduction", Form_Alert.enmType.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    this.Alert("Déterminer l'identifiant en double-cliquant sur la réduction", Form_Alert.enmType.Info);
                    return;
                }
                Class_Discount.usp_tblDiscountUpdate(int.Parse(txtID.Text), decimal.Parse(txtPrice.Text), txtDesc.Text, txtNum.Text);
                this.Alert("Modifié avec succés", Form_Alert.enmType.Success);
                GetData();
                Clean();
            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627)
                {
                    this.Alert("Cet étudiant a déjà fait une réduction", Form_Alert.enmType.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void nButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    this.Alert("Déterminer l'identifiant en double-cliquant sur la réduction", Form_Alert.enmType.Info);
                    return;
                }
                DialogResult dr = MessageBox.Show("Voulez-vous vraiment supprimer cette réduction ?", "رسالة تحذيرية", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_Discount.usp_tblDiscountDelete(int.Parse(txtID.Text));
                    this.Alert("Supprimé avec succés", Form_Alert.enmType.Success);
                    GetData();
                    Clean();
                }
            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627)
                {
                    this.Alert("Cet étudiant a déjà fait une réduction", Form_Alert.enmType.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNum.Text = grdView.CurrentRow.Cells[3].Value.ToString();
            txtID.Text = grdView.CurrentRow.Cells[0].Value.ToString();
            txtPrice.Text = grdView.CurrentRow.Cells[1].Value.ToString();
            txtDesc.Text = grdView.CurrentRow.Cells[2].Value.ToString();
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
        private void FGestionRemise_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
