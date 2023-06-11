using CustomAlertBoxDemo;
using Gestion_de_l_école.ColorClass;
using SchoolManagment3.BL;
using SchoolManagment3.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagment3
{
    public partial class FAjouterEtudinat : Form
    {
        bool _check;
        public FAjouterEtudinat(bool check)
        {
            InitializeComponent();
            GetYear();
            btnSauv.Enabled = false;

            GetNivau();
            cmbFilier_SelectedIndexChanged(null, null);
            if (check == true)
            {
                _check = true;
                this.Text = "Modifier les données des étudiants";
                Readonly(false);
                btnSauv.Enabled = true;
                DataTable dt = Class_student.usp_GetStudentByID(FGestionDesEtudiant.ID);
                foreach (DataRow dr in dt.Rows)
                {
                    txtid.Text = dr["NumInscription"].ToString();
                    txtFullName.Text = dr["FullName"].ToString();
                    cmbGender.Text = dr["Gender"].ToString();
                    dtpBirthday.Text = dr["birthday"].ToString();
                    txtBirthPlace.Text = dr["birthPlace"].ToString();
                    txtNationalite.Text = dr["Nationalite"].ToString();
                    txtAdress.Text = dr["adress"].ToString();
                    dtpInscriptionDate.Text = dr["InscriptionDate"].ToString();
                    cmbYearSchool.Text = dr["SchoolYear"].ToString();
                    cmbniveau.Text = dr["niveau"].ToString();
                    cmbFilier.Text = dr["filier"].ToString();
                    cmbClass.Text = dr["class"].ToString();
                    txtInscriptionFees.Text = dr["Registrationfees"].ToString();
                    txtMonthlyFees.Text = dr["Monthlyfees"].ToString();
                    txtFatherName.Text = dr["fatherName"].ToString();
                    txtFatherJob.Text = dr["fatherJob"].ToString();
                    txtHandphone.Text = dr["handphone"].ToString();
                    txtHomePhone.Text = dr["homephone"].ToString();

                    byte[] Arr = (byte[])dr["photo"];
                    MemoryStream ms = new MemoryStream(Arr);
                    imgStudent.Image = Image.FromStream(ms);

                }
            }
            else
            {
                _check = false;
                this.Text = "Ajouter Etudiant";
                Readonly(true);
            }

        }

        private void Readonly(bool state)
        {
            txtid.ReadOnly = txtFullName.ReadOnly = state;
        }
        private void GetYear()
        {
            DataTable dt = Class_Classes.Ps_GetYears();
            if (dt.Rows.Count > 0)
            {
                cmbYearSchool.ValueMember = "idyear";
                cmbYearSchool.DisplayMember = "SchoolYear";
                cmbYearSchool.DataSource = dt;
                cmbYearSchool.Text = dt.Rows[dt.Rows.Count - 1][1].ToString();
            }

        }

        private void GetNivau()
        {
            DataTable dt = Class_Filiere.PS_SelectNivau();
            if (dt.Rows.Count > 0)
            {
                cmbniveau.ValueMember = "idNiveau";
                cmbniveau.DisplayMember = "LabelNivau";
                cmbniveau.DataSource = dt;
            }

        }

        private void btnSauv_Click(object sender, EventArgs e)
        {
            if (_check == false)
            {
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is TextBox)
                    {
                        if (c == txtNationalite || c == txtAdress)
                        {
                            continue;
                        }
                        if (c.Text == "")
                        {

                            MessageBox.Show("");
                            this.Alert("Veuillez remplir tous les champs obligatoires", Form_Alert.enmType.Info);

                            return;
                            break;
                        }
                    }
                }

                foreach (Control c in groupBox2.Controls)
                {
                    if (c is TextBox )
                    {
                        if (c.Text == "")
                        {
                            this.Alert("Veuillez remplir tous les champs obligatoires", Form_Alert.enmType.Info);
                            return;
                            break;
                        }
                    }
                }

                try
                {
                    MemoryStream ms = new MemoryStream();
                    imgStudent.Image.Save(ms, imgStudent.Image.RawFormat);
                    byte[] arr = ms.ToArray();


                    Class_student.PS_addStudent(txtid.Text, txtFullName.Text,
                        cmbGender.Text, dtpBirthday.Value, txtBirthPlace.Text, txtNationalite.Text, txtFatherName.Text, txtFatherJob.Text,
                       txtAdress.Text, txtHandphone.Text, txtHomePhone.Text, arr, true, dtpInscriptionDate.Value,
                       Convert.ToDecimal(txtInscriptionFees.Text), Convert.ToDecimal(txtMonthlyFees.Text), Convert.ToInt32(cmbClass.SelectedValue),
                       Convert.ToInt32(cmbYearSchool.SelectedValue));
                    this.Alert("Ajoutée avec succès", Form_Alert.enmType.Success);
                    
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        this.Alert("Numéro d'inscription déja existe", Form_Alert.enmType.Warning);
                    }
                }
                catch (Exception)
                {
                    this.Alert("Une erreur s'est produite lors de l'ajout de l'élève", Form_Alert.enmType.Error);
                }
            }
            else
            {
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is TextBox || c is ComboBox)
                    {
                        if (c.Text == "")
                        {
                            this.Alert("Veuillez remplir tous les champs obligatoires", Form_Alert.enmType.Info);
                            return;
                            break;
                        }
                    }
                }

                foreach (Control c in groupBox2.Controls)
                {
                    if (c is TextBox || c is ComboBox)
                    {
                        if (c.Text == "")
                        {
                            this.Alert("Veuillez remplir tous les champs obligatoires", Form_Alert.enmType.Info);
                            return;
                            break;
                        }
                    }
                }

                try
                {
                    MemoryStream ms = new MemoryStream();
                    imgStudent.Image.Save(ms, imgStudent.Image.RawFormat);
                    byte[] arr = ms.ToArray();

                    Class_student.usp_tblStudentUpdate(txtid.Text, txtFullName.Text,
                        cmbGender.Text, dtpBirthday.Value, txtBirthPlace.Text, txtNationalite.Text, txtFatherName.Text, txtFatherJob.Text,
                       txtAdress.Text, txtHandphone.Text, txtHomePhone.Text, arr, true, dtpInscriptionDate.Value, Convert.ToDecimal(txtInscriptionFees.Text), Convert.ToDecimal(txtMonthlyFees.Text), Convert.ToInt32(cmbClass.SelectedValue), Convert.ToInt32(cmbYearSchool.SelectedValue));
                    this.Alert("Les informations ont été modifiées avec succè", Form_Alert.enmType.Success);
                }
                catch (Exception)
                {
                    this.Alert("Une erreur s'est produite lors de l'ajout de l'élève", Form_Alert.enmType.Error);
                }
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            Readonly(false);
            btnSauv.Enabled = true;
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

            foreach (Control c in groupBox3.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            pictureBox1_Click(null, null);
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "All Files |*.*|JPG|*.jpg|PNG|*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imgStudent.Image = Image.FromFile(ofd.FileName);
                }
                else
                {
                    Console.Write("");
                }

            }
            catch (Exception)
            {
                this.Alert("Quelque chose s'est mal passé, vous pouvez ignorer ce message !", Form_Alert.enmType.Error);
            }
        }

        private void cmbniveau_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = Class_student.Ps_GetFilierByNivau(Convert.ToInt32(cmbniveau.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                cmbFilier.DisplayMember = "labelFiliere";
                cmbFilier.ValueMember = "idFiliere";
                cmbFilier.DataSource = dt;
            }
            cmbFilier_SelectedIndexChanged(null, null);
        }

        private void cmbFilier_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = Class_student.Ps_GetClassByFiliere(Convert.ToInt32(cmbFilier.SelectedValue), Convert.ToInt32(cmbYearSchool.SelectedValue));
            cmbClass.DisplayMember = "LabelC";
            cmbClass.ValueMember = "idClass";
            cmbClass.DataSource = dt;
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCloseImage_Click(object sender, EventArgs e)
        {

        }

        private void txtHomePhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHandphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtInscriptionFees_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnsave_Click(object sender, EventArgs e)
        {
           

            }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
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
            btnImage.BackColor = ThemeColor.PrimaryColor;
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void FAjouterEtudinat_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void cmbYearSchool_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            imgStudent.Image = SchoolManagment3.Properties.Resources.student;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
    }

