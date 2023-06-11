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
    public partial class FAjouterPaiement : Form
    {
        public FAjouterPaiement()
        {
            InitializeComponent();
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        int FeeId = 0;
        decimal price = 0.00M;
        decimal M = 0.00M;

        public void GetFeeType()
        {

            DataTable dt = Class_Fees.usp_tblFeetypeSelect();
            comboBox1.DisplayMember = "labelFee";
            comboBox1.ValueMember = "idfeesType";
            comboBox1.DataSource = dt;
        }

        public void GetOtherFees()
        {
            listView1.Items.Clear();
            DataTable dt = Class_OtherFees.usp_tblOtherFeesSelect();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr[0].ToString());
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                listView1.Items.Add(item);
                //listView1.Columns[0].Width = 0;
            }
        }
        private void Clear()
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

            //comboBox1.Items.Clear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Frais d'inscription et d'assurance")
                {
                    price = decimal.Parse(txtInscPrice.Text);
                    listView1.Items.Clear();
                    txtDiscount.Text = 0.ToString();
                }
                else
                {
                    price = decimal.Parse(txtMonthlyPrice.Text);
                    decimal discount = Class_Fees.usp_getMyDiscoutn(txtNum.Text);
                    if (discount == null)
                    {
                        txtDiscount.Text = 0.ToString();
                    }
                    else
                    {
                        txtDiscount.Text = discount.ToString();
                        price -= discount;
                        GetOtherFees();
                    }
                }

                txtTotal.Text = (price + M).ToString();
            }
            catch (Exception)
            {

                //
            }
        }

        private void txtPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (Exception)
            {

                //throw;
            }
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal Total = 0.00M;
                if (txtTotal.Text != "" && txtPaid.Text != "")
                {
                    Total += decimal.Parse(txtTotal.Text);
                    txtRest.Text = (Total - decimal.Parse(txtPaid.Text)).ToString();
                }
            }
            catch (Exception ex)
            {

                //
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            txtPaid_TextChanged(null, null);
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (e.CurrentValue == CheckState.Unchecked)
                {
                    price += decimal.Parse(
                        this.listView1.Items[e.Index].SubItems[2].Text);
                }
                else if ((e.CurrentValue == CheckState.Checked))
                {
                    price -= decimal.Parse(
                        this.listView1.Items[e.Index].SubItems[2].Text);
                }
                // Output the price to TextBox1.
                txtTotal.Text = (price + M).ToString();
            }
            catch (Exception ex)
            {

                //
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                new FGestionDesEtudiant("Fees").ShowDialog();
                txtNum.Text = FGestionDesEtudiant.ID;
                txtName.Text = FGestionDesEtudiant.SName;
                txtYear.Text = FGestionDesEtudiant.Year;
                txtMonthlyPrice.Text = FGestionDesEtudiant.MonthlyPrice;
                txtInscPrice.Text = FGestionDesEtudiant.InscriptionPrice;
                txtFiliere.Text = FGestionDesEtudiant.Filiers;
                txtClass.Text = FGestionDesEtudiant.Classe;
                if (txtMonthlyPrice.Text != "" && txtInscPrice.Text != "")
                {
                    DataTable dt = Class_Fees.usp_getmylatDue(txtNum.Text);
                    txtM.Text = dt.Rows[0][0].ToString();
                    M = decimal.Parse(txtM.Text);
                    GetFeeType();
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(txtPaid.Text) <= 0)
            {
                this.Alert("Le montant payé ne doit pas être nul", Form_Alert.enmType.Info);
                return;
            }
            if (decimal.Parse(txtRest.Text) < 0)
            {
                this.Alert("Le montant restant est inférieur à zéro,\nvérifiez ce que vous avez saisi", Form_Alert.enmType.Info);
                return;
            }
            try
            {
                DataTable dtPaimentDetail = new DataTable();
                dtPaimentDetail.Columns.Add("idMonth");
                dtPaimentDetail.Columns.Add("NumInscription");
                dtPaimentDetail.Columns.Add("idOtherFees");

                foreach (ListViewItem it in listView1.Items)
                {
                    if (it.Checked)
                    {
                        dtPaimentDetail.Rows.Add(Convert.ToInt32(comboBox1.SelectedValue), txtNum.Text, Convert.ToInt32(it.SubItems[0].Text));
                    }
                }
                if (dtPaimentDetail.Rows.Count == 0)
                {
                    dtPaimentDetail.Rows.Add(Convert.ToInt32(comboBox1.SelectedValue), txtNum.Text, null);
                }

                Class_Fees.usp_tblFeesInsert(txtYear.Text, Convert.ToDecimal(txtTotal.Text), Convert.ToDecimal(txtPaid.Text), Convert.ToDecimal(txtRest.Text), dateTimePicker1.Value, dtPaimentDetail, txtNote.Text);
                this.Alert("Enregistré avec succès", Form_Alert.enmType.Success);
                FeeId = Class_Fees.usp_getLastFees();
                Clear();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void nButton1_Click(object sender, EventArgs e)
        {
     
            }
        

        private void nButton2_Click(object sender, EventArgs e)
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
            nButton3.BackColor = ThemeColor.PrimaryColor;
        }
            private void FAjouterPaiement_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void nButton3_Click(object sender, EventArgs e)
        {
            FAjouterFrais f = new FAjouterFrais();
            f.Show();
        }
    }
}
