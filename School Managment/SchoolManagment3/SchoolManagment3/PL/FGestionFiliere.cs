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
    public partial class FGestionFiliere : Form
    {
        public FGestionFiliere()
        {
            InitializeComponent();
            GetData();
            DataTable dt = Class_Filiere.PS_SelectNivau();
            cmbNiveau.DisplayMember = "LabelNivau";
            cmbNiveau.ValueMember = "idNiveau";
            cmbNiveau.DataSource = dt;
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
           
        }
        private void GetData()
        {
            DataTable dt = Class_Filiere.PS_SelectFiliere();
            grdView.DataSource = dt;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
         
        }

        private void grdView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            txtId.Text = grdView.SelectedRows[0].Cells[0].Value.ToString();
            txtFiliere.Text = grdView.SelectedRows[0].Cells[1].Value.ToString();
            cmbNiveau.Text = grdView.SelectedRows[0].Cells[2].Value.ToString();
            nButton3.Enabled = false;

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
        private void FGestionFiliere_Load(object sender, EventArgs e)
        {
            LoadTheme();
            nButton3.Enabled = false;
            txtFiliere.ReadOnly = true;

        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtFiliere.Clear();
            //cmbNiveau.Text = "";
            nButton3.Enabled= true;
            txtFiliere.ReadOnly = false;
        }

        private void nButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("");
                    this.Alert("Veuillez préciser l'ID de la Filiere", Form_Alert.enmType.Info);

                    return;
                }
                if (txtFiliere.Text == "" || cmbNiveau.Text == "")
                {
                    this.Alert("Veuillez remplir tout les champs", Form_Alert.enmType.Warning);
                    return;
                }
                Class_Filiere.PS_UpdateFiliere(int.Parse(txtId.Text), txtFiliere.Text, Convert.ToInt32(cmbNiveau.SelectedValue));
                this.Alert("Modifié avec succès", Form_Alert.enmType.Success);
                GetData();
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
                if (txtId.Text == "")
                {
                    this.Alert("Veuillez préciser l'ID de la Filiere", Form_Alert.enmType.Info);
                    return;
                }
                DialogResult dr = MessageBox.Show("Voulez-vous vraiment supprimer cette Filière?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_Filiere.PS_RemoveFiliere(int.Parse(txtId.Text));
                    this.Alert("Supprimé avec succès", Form_Alert.enmType.Success);
                    txtId.Clear();
                    txtFiliere.Clear();
                    GetData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFiliere.Text) || string.IsNullOrEmpty(cmbNiveau.Text))
            {
                this.Alert("Merci de remplir tous les champs", Form_Alert.enmType.Info);
                return;
            }

            Class_Filiere.PS_InsertFiliere(txtFiliere.Text, Convert.ToInt32(cmbNiveau.SelectedValue));
            this.Alert("La section a été ajoutée avec succès", Form_Alert.enmType.Success);
            txtFiliere.Clear();
            GetData();
            nButton3.Enabled = false;
        }
    }
}
