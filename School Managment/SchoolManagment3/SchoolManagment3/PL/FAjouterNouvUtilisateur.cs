using CustomAlertBoxDemo;
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
    public partial class FAjouterNouvUtilisateur : Form
    {
        public FAjouterNouvUtilisateur()
        {
            InitializeComponent();
        }
        string user;
        private void loadData()
        {
            DataTable dt = Class_Users.usp_tblUsersSelect();
            dataGridView1.DataSource = dt;
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
        }
       
        private void nButton4_Click(object sender, EventArgs e)
        {
            DataTable dt = Class_Users.usp_searchUsr(txtSearch.Text);
            dataGridView1.DataSource = dt;
        }

        private void FAjouterNouvUtilisateur_Load(object sender, EventArgs e)
        {
            loadData();

            dataGridView1.Columns[3].Visible = false;
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    if (c == txtEmail)
                    {
                        continue;
                    }
                    if (c.Text == "")
                    {
                        this.Alert("Veuillez remplir tout les champs", Form_Alert.enmType.Info);
                        return;
                    }
                }
            }

            try
            {
                if (txtPassword.Text != txtPasswordConfirm.Text)
                {
                    this.Alert("Le mot de passe ne correspond pas", Form_Alert.enmType.Warning);
                    txtPasswordConfirm.Clear();
                    return;
                }

                Class_Users.usp_tblUsersInsert(txtUsername.Text, txtFullName.Text, txtPassword.Text, txtEmail.Text);
                this.Alert("Ajouté avec succès", Form_Alert.enmType.Success);
                loadData();
                Clear();
            }
            catch (Exception ex)
            {
                this.Alert("Cet utilisateur ne peut pas être ajouté,\n il existe peut-être", Form_Alert.enmType.Warning);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    if (c == txtEmail)
                    {
                        continue;
                    }
                    if (c.Text == "")
                    {
                        this.Alert("Veuillez remplir tout les champs", Form_Alert.enmType.Info);
                        return;
                    }
                }
            }

            try
            {
                if (txtPassword.Text != txtPasswordConfirm.Text)
                {
                    this.Alert("Le mot de passe ne correspond pas", Form_Alert.enmType.Warning);
                    txtPasswordConfirm.Clear();
                    return;
                }
                if (txtUsername.Text.ToLower() == "admin")
                {
                    this.Alert("Le rang de manager ne peut pas être \ntéléchargé", Form_Alert.enmType.Error);
                    return;
                }
                Class_Users.usp_tblUsersUpdate(txtUsername.Text, txtFullName.Text, txtPassword.Text, txtEmail.Text);
                this.Alert("Modifié avec succès", Form_Alert.enmType.Success);
                loadData();
                Clear();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                string username = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if (username == "Admin")
                {
                    this.Alert("Cet utilisateur ne peut pas être supprimé", Form_Alert.enmType.Error);
                    return;
                }
                DialogResult dr = MessageBox.Show("Voulez-vous vraiment supprimer cet utilisateur", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_Users.usp_tblUsersDelete(username);
                    this.Alert("Supprimé avec succès", Form_Alert.enmType.Success);
                    loadData();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                this.Alert("Cet utilisateur ne peut pas être supprimé", Form_Alert.enmType.Info);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsername.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            user = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtFullName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtEmail.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtPassword.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtPasswordConfirm.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
