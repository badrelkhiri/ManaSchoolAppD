using CustomAlertBoxDemo;
using Gestion_de_l_école.ColorClass;
using SchoolManagment3.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagment3.PL
{
    public partial class FGestionPaiement : Form
    {
        public FGestionPaiement()
        {
            InitializeComponent();
            LoadData();
            GetYear();
            GetFiliere();
        }
        private void GetFiliere()
        {
            DataTable dt = Class_Classes.Ps_GetFiliers();
            cmbFiliere.DisplayMember = "LabelFiliere";
            cmbFiliere.ValueMember = "idFiliere";
            cmbFiliere.DataSource = dt;
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void GetYear()
        {
            DataTable dt = Class_Classes.Ps_GetYears();
            cmbYears.ValueMember = "idyear";
            cmbYears.DisplayMember = "SchoolYear";
            cmbYears.DataSource = dt;
            cmbYears.Text = dt.Rows[dt.Rows.Count - 1][1].ToString();

        }
        private void LoadData()
        {
            DataTable dt = Class_Fees.usp_SelectFees();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtNum.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtIdFee.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtYear.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtFeeName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtTotal.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtPaid.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtRest.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtNote.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void nButton1_Click(object sender, EventArgs e)
        {
            int result;

            if (int.TryParse(txtSearchID.Text, out result))
            {
                DataTable dt = Class_Fees.usp_SelectFeesById(result);
                dataGridView1.DataSource = dt;
            }
            else
            {
                this.Alert("Entrez le bon numéro de lien", Form_Alert.enmType.Warning);
            }
        }

        private void nButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DataTable dt = Class_Fees.usp_SelectFeesByName(textBox1.Text);
                dataGridView1.DataSource = dt;
            }
        }

        private void nButton3_Click(object sender, EventArgs e)
        {
            if (cmbClass.Text != "")
            {
                DataTable dt = Class_Fees.usp_SelectFeesByClass(Convert.ToInt32(cmbClass.SelectedValue));
                dataGridView1.DataSource = dt;
            }
        }

        private void nButton4_Click(object sender, EventArgs e)
        {

        }

        private void nButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    this.Alert("Vous devez d'abord sélectionner la facture que vous souhaitez", Form_Alert.enmType.Info);
                    return;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Voulez-vous vraiment supprimer cette facture", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        Class_Fees.usp_tblFeesDelete(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                        this.Alert("Supprimé avec succès", Form_Alert.enmType.Success);
                        LoadData();
                    }
                }
            }
            catch (Exception)
            {
                this.Alert("Une erreur s'est produite lors de la suppression", Form_Alert.enmType.Error);
            }
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTotal.Text != "")
                {
                    decimal paid = 0.00M;
                    if (txtPaid.Text == "")
                    {
                        paid = 0.00M;
                    }
                    else
                    {
                        paid = decimal.Parse(txtPaid.Text);
                    }

                    txtRest.Text = ((decimal.Parse(txtTotal.Text)) - (paid)).ToString();
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void txtPaid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void nButton6_Click(object sender, EventArgs e)
        {

        }

        private void cmbFiliere_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbClass.Enabled = true;
            DataTable dt = Class_student.Ps_GetClassByFiliere(Convert.ToInt32(cmbFiliere.SelectedValue), Convert.ToInt32(cmbYears.SelectedValue));
            cmbClass.DisplayMember = "LabelC";
            cmbClass.ValueMember = "idClass";
            cmbClass.DataSource = dt;
        }

        private void cmbYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFiliere_SelectedIndexChanged(null, null);

        }

        private void txtSearchID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void nButton4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdFee.Text))
                {
                    this.Alert("Merci de préciser le bon numéro du lien", Form_Alert.enmType.Info);
                    return;
                }
                else
                {
                    Class_Fees.usp_tblFeesUpdate(int.Parse(txtIdFee.Text), decimal.Parse(txtTotal.Text), decimal.Parse(txtPaid.Text), decimal.Parse(txtRest.Text), txtNote.Text);
                    this.Alert("Mis à jour avec succés", Form_Alert.enmType.Success);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                this.Alert("Une erreur s'est produite lors de la suppression", Form_Alert.enmType.Error);
            }
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
            nButton1.BackColor = ThemeColor.PrimaryColor;
            nButton2.BackColor = ThemeColor.PrimaryColor;
            nButton3.BackColor = ThemeColor.PrimaryColor;
        }
        private void FGestionPaiement_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void nButton8_Click(object sender, EventArgs e)
        {
            //this.Close();

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
