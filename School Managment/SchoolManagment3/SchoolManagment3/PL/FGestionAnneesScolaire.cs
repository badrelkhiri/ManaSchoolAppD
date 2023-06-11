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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagment3.PL
{
    public partial class FGestionAnneesScolaire : Form
    {
        public FGestionAnneesScolaire()
        {
            InitializeComponent();
            GetData();

        }
        public void GetData()
        {
            DataTable dt = Class_SchoolYear.PS_SelectSchoolYear();
            grdView.DataSource = dt;
            grdView.Columns[0].Visible = false;
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void grdView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = grdView.SelectedRows[0].Cells[0].Value.ToString();
            txtYear.Text = grdView.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {

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
        private void FGestionAnneesScolaire_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void nButton1_Click(object sender, EventArgs e)
        {
            string pattern = "^[0-9]{4}-[0-9]{4}$";
            Regex reg = new Regex(pattern);
            try
            {
                if (txtYear.Text == "" || !reg.IsMatch(txtYear.Text))
                {
                    this.Alert("Ce que vous avez entré ne correspond pas au modèle demandé", Form_Alert.enmType.Warning);

                    return;
                }

                Class_SchoolYear.PS_addSchoolYear(txtYear.Text);
                this.Alert("Année ajoutée avec succès", Form_Alert.enmType.Success);
                GetData();
                txtYear.Text = "____-____";
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void txtYearA_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtYear_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtYear_Enter(object sender, EventArgs e)
        {
            if (txtYear.Text == "____-____")
            {
                txtYear.Clear();
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtYear.Text = "____-____";
        }

        private void nButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    this.Alert("Sélectionnez d'abord l'année requise", Form_Alert.enmType.Info);
                    return;
                }

                Class_SchoolYear.PS_UpdateSchoolYear(int.Parse(txtId.Text), txtYear.Text);
                this.Alert("L'année a été modifiée avec succès", Form_Alert.enmType.Success);
                txtYear.Clear();
                txtId.Clear();
                GetData();
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }
        }

        private void btnSupprimer_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    this.Alert("Sélectionnez d'abord l'année requise", Form_Alert.enmType.Info);
                    return;
                }
                DialogResult dr = MessageBox.Show("Voulez-vous vraiment supprimer l'année scolaire ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_SchoolYear.PS_DeleteSchoolYear(int.Parse(txtId.Text));
                this.Alert("Année supprimé avec succès", Form_Alert.enmType.Success);
                    txtYear.Clear();
                    txtId.Clear();
                    GetData();
                }
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }
        }
    
    } 
}
