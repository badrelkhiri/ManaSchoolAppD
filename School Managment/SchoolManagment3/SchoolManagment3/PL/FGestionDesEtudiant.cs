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

namespace SchoolManagment3
{
    public partial class FGestionDesEtudiant : Form
    {
        public static string ID;
        public static string SName;
        public static string Year;
        public static string Filiers;
        public static string Classe;
        public static string MonthlyPrice;
        public static string InscriptionPrice;

        string _check;
        public FGestionDesEtudiant(string check)
        {
            _check = check;
            InitializeComponent();
            GetYear();
            GetFiliere();
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

        private void GetYear()
        {
            DataTable dt = Class_Classes.Ps_GetYears();
            cmbYears.ValueMember = "idyear";
            cmbYears.DisplayMember = "SchoolYear";
            cmbYears.DataSource = dt;
            cmbYears.Text = dt.Rows[dt.Rows.Count - 1][1].ToString();

        }
        private void GetData()
        {
            DataTable dt = Class_student.usp_tblStudentSelect();
            dataGridView1.DataSource = dt;
        }

        private void btnUpd_Click(object sender, EventArgs e)
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
            nButton5.BackColor = ThemeColor.PrimaryColor;
            nButton6.BackColor = ThemeColor.PrimaryColor;
        }
        private void FGestionDesEtudiant_Load(object sender, EventArgs e)
        {
            LoadTheme();
            GetData();

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = Class_student.usp_tblStudentSelectByName(txtName.Text);
            dataGridView1.DataSource = dt;
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = Class_student.usp_tblStudentSelectByNumber(txtNum.Text);
            dataGridView1.DataSource = dt;
        }

        private void btnRechPaeSection_Click(object sender, EventArgs e)
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

        private void btnRechDateIn_Click(object sender, EventArgs e)
        {
            
        }
        private void copyAlltoClipboard()
        {
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAffiEtModifi_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_check == "Discount")
            {
                ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                SName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                this.Close();
            }
            else if (_check == "Fees")
            {
                ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                SName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Year = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                Filiers = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                Classe = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                MonthlyPrice = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                InscriptionPrice = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
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
                ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                new FAjouterEtudinat(true).ShowDialog();
            }
            catch
            {

                
            }
        }

        private void nButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string num = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult dr = MessageBox.Show("Voulez-vous vraiment supprimer cet étudiant ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_student.usp_tblStudentDelete(num);
                    this.Alert("Supprimé avec succès", Form_Alert.enmType.Success);
                    GetData();
                }
            }
            catch (SqlException)
            {

                //MessageBox.Show(ex.Message + ex.Number);
            }
            catch
            {
                //
            }
        }

        private void nButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    this.Alert("Il n'y a pas de données", Form_Alert.enmType.Warning);
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                copyAlltoClipboard();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;
                this.Alert("Quelque chose s'est mal passé", Form_Alert.enmType.Error);
            }
        }

        private void btnMu_Click(object sender, EventArgs e)
        {

        }

        private void nButton6_Click(object sender, EventArgs e)
        {
            DataTable dt = Class_student.Usp_SearchStudentbyDate(dateTimePicker1.Value, dateTimePicker2.Value);
            dataGridView1.DataSource = dt;
        }

        private void nButton5_Click(object sender, EventArgs e)
        {
            if (cmbClass.Text != "")
            {
                DataTable dt = Class_student.Usp_SearchStudentbyClass(Convert.ToInt32(cmbClass.SelectedValue));
                dataGridView1.DataSource = dt;
            }
        }
        public static string Num;
        public static string Annee;
        private void nButton7_Click(object sender, EventArgs e)
        {
            try
            {
                Num = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Annee = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                Rapport f = new Rapport();
                f.Show();

            }
            catch (Exception)
            {

                //MessageBox.Show(ex.Message);
            }
        }

        private void nButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
