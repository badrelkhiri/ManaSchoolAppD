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
    public partial class FStatistiquesDePaiement : Form
    {
        public FStatistiquesDePaiement()
        {
            InitializeComponent();
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
            btnNouveau.BackColor = ThemeColor.PrimaryColor;
            nButton1.BackColor = ThemeColor.SecondaryColor;
         
        }
        private void FStatistiquesDePaiement_Load(object sender, EventArgs e)
        {
            LoadTheme();
            GetFiliere();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string year = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            string num = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            DataTable dt = Class_Fees.usp_getMu(year, num);
            txtTotal.Text = dt.Rows[0][0].ToString();
            txtREst.Text = dt.Rows[0][1].ToString();
        }

        private void btnSearchByDate_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Class_Fees.usp_GetNombreOfFees(txtYear.Text, Convert.ToInt32(cmbFiliere.SelectedValue));
                dataGridView1.DataSource = dt;
                txtNombreRecu.Text = dt.Rows.Count.ToString();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void nButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Class_Fees.usp_GetFeesByDate(dateTimePicker1.Value.Date);
                dataGridView1.DataSource = dt;
                txtNombreRecu.Text = dt.Rows.Count.ToString();
                decimal daily = 0.00M;
                foreach (DataRow dr in dt.Rows)
                {
                    daily += Convert.ToDecimal(dr[6]);
                }
                txtDaily.Text = daily.ToString();
            }
            catch (Exception ex)
            {

                // throw;
            }
        }
    }
}
