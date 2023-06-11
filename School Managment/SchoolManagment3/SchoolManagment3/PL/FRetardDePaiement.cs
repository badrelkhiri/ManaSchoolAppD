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
    public partial class FRetardDePaiement : Form
    {
        public FRetardDePaiement()
        {
            InitializeComponent();
            GetYear();
            GetFiliere();
            GetFeeType();
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void GetFiliere()
        {
            DataTable dt = Class_Classes.Ps_GetFiliers();
            cmbFiliere.DisplayMember = "LabelFiliere";
            cmbFiliere.ValueMember = "idFiliere";
            cmbFiliere.DataSource = dt;
        }

        public void GetFeeType()
        {

            DataTable dt = Class_Fees.usp_tblFeetypeSelect();
            cmbMonth.DisplayMember = "labelFee";
            cmbMonth.ValueMember = "idfeesType";
            cmbMonth.DataSource = dt;
            cmbMonth2.DisplayMember = "labelFee";
            cmbMonth2.ValueMember = "idfeesType";
            cmbMonth2.DataSource = dt;
        }
        private void GetYear()
        {
            DataTable dt = Class_Classes.Ps_GetYears();
            cmbYears.ValueMember = "idyear";
            cmbYears.DisplayMember = "SchoolYear";
            cmbYears.DataSource = dt;

            cmbYear.ValueMember = "idyear";
            cmbYear.DisplayMember = "SchoolYear";
            cmbYear.DataSource = dt;
            cmbYear.Text = dt.Rows[dt.Rows.Count - 1][1].ToString();
            cmbYears.Text = dt.Rows[dt.Rows.Count - 1][1].ToString();

        }

        private void btnSearchByClass_Click(object sender, EventArgs e)
        {
            DataTable dt = Class_Fees.usp_getLateThismonthNoClasses(Convert.ToInt32(cmbYears.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue));
            dataGridView1.DataSource = dt;
    
        }

        private void cmbFiliere_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = Class_student.Ps_GetClassByFiliere(Convert.ToInt32(cmbFiliere.SelectedValue), Convert.ToInt32(cmbYear.SelectedValue));
            cmbClass.DisplayMember = "LabelC";
            cmbClass.ValueMember = "idClass";
            cmbClass.DataSource = dt;
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFiliere_SelectedIndexChanged(null, null);
        }

        private void SearchByClass_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            DataTable dt = Class_Fees.usp_getLateThismonthNoClasses(Convert.ToInt32(cmbYears.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue));
            dataGridView1.DataSource = dt;
        }

        private void nButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = Class_Fees.usp_getLateThismonth(Convert.ToInt32(cmbClass.SelectedValue), Convert.ToInt32(cmbMonth2.SelectedValue));
            dataGridView1.DataSource = dt;
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
            btnNouveau.BackColor = ThemeColor.PrimaryColor;
        }
        private void FRetardDePaiement_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
