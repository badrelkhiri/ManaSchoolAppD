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
    public partial class FGestionDesClasses : Form
    {
        public FGestionDesClasses()
        {
            InitializeComponent();
            GetFilieres();
            GetYear(cmbYear);
            GetYear(cmbSearch);
            Getdata();
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void GetFilieres()
        {
            DataTable dt = Class_Classes.Ps_GetFiliers();
            cmbFiliere.ValueMember = "idFiliere";
            cmbFiliere.DisplayMember = "labelFiliere";
            cmbFiliere.DataSource = dt;

        }

        private void GetYear(ComboBox com)
        {
            DataTable dt = Class_Classes.Ps_GetYears();
            com.ValueMember = "idyear";
            com.DisplayMember = "SchoolYear";
            com.DataSource = dt;
            cmbYear.Text = dt.Rows[dt.Rows.Count - 1][1].ToString();
            cmbSearch.Text = dt.Rows[dt.Rows.Count - 1][1].ToString();

        }


        private void Getdata()
        {
            DataTable dt = Class_Classes.PS_GetClassesData();

            grdView.DataSource = dt;
            grdView.Columns[0].Visible = false;
        }


        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = Class_Classes.PS_GetClassesDataByYear(Convert.ToInt32(cmbSearch.SelectedValue));
            grdView.DataSource = dt;
            grdView.Columns[0].Visible = false;
        }

        private void grdView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = grdView.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = grdView.SelectedRows[0].Cells[1].Value.ToString();
            cmbFiliere.Text = grdView.SelectedRows[0].Cells[2].Value.ToString();
            cmbYear.Text = grdView.SelectedRows[0].Cells[3].Value.ToString();
            //btnSauveg.Enabled = true;
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            txtName.ReadOnly = false;
            txtId.Clear();
            txtName.Clear();
            btnSauveg.Enabled = true;
        }

        private void btnSauveg_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                try
                {
                    if (txtName.Text == "" || cmbFiliere.Text == "" || cmbYear.Text == "")
                    {
                        this.Alert("Merci de remplir tous les champs", Form_Alert.enmType.Info);
                        return;
                    }
                    Class_Classes.Ps_InsertClasses(txtName.Text, Convert.ToInt32(cmbFiliere.SelectedValue), Convert.ToInt32(cmbYear.SelectedValue));
                    this.Alert("Ajouté avec succès", Form_Alert.enmType.Success);
                    Getdata();
                }
                catch (SqlException ex)
                {

                    if (ex.Number == 3609)
                    {
                        this.Alert("Cette section exist déjà", Form_Alert.enmType.Warning);
                    }
                }
                catch (Exception ex)
                {
                    this.Alert("Une erreur s'est produite lors de l'exécution de cette opération", Form_Alert.enmType.Error);
                }

            }
            else if (txtId.Text != "")
            {
                try
                {
                    if (txtName.Text == "" || cmbFiliere.Text == "" || cmbYear.Text == "")
                    {
                        this.Alert("Merci de remplir tous les champs", Form_Alert.enmType.Info);
                        return;
                    }
                    Class_Classes.Ps_UpdateClasses(int.Parse(txtId.Text), txtName.Text, Convert.ToInt32(cmbFiliere.SelectedValue), Convert.ToInt32(cmbYear.SelectedValue));
                    this.Alert("Modifié avec succès", Form_Alert.enmType.Success);
                    Getdata();
                    txtId.Clear();
                    txtName.Clear();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 3609)
                    {
                        this.Alert("Cette section exist déjà", Form_Alert.enmType.Warning);
                    }

                }
                catch (Exception)
                {
                    this.Alert("Une erreur s'est produite lors de l'exécution de cette opération", Form_Alert.enmType.Error);
                }
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    this.Alert("Veuillez sélectionner un ID de classe", Form_Alert.enmType.Info);
                    return;
                }
                DialogResult dr = MessageBox.Show("Voulez-vous vraiment supprimer cette section ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_Classes.Ps_DeleteClasses(int.Parse(txtId.Text));
                    this.Alert("Supprimé avec succès", Form_Alert.enmType.Success);
                    Getdata();
                    txtId.Clear();
                    txtName.Clear();
                }
            }
            catch
            {
                this.Alert("Une erreur s'est produite lors de l'exécution de cette opération", Form_Alert.enmType.Error);
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
        }
        private void FGestionDesClasses_Load(object sender, EventArgs e)
        {
            LoadTheme();
            btnSauveg.Enabled = false;

        }
    }
}
