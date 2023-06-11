using Microsoft.Reporting.WinForms;
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
    public partial class Rapport : Form
    {
        public Rapport()
        {
            InitializeComponent();
        }
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename= |DataDirectory|GestionEco.mdf; Integrated Security=True");
            DataSet ds = new DataSet();

        private void Rapport_Load(object sender, EventArgs e)
        {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [NumInscription], [FullName], [Gender], [birthday], [birthPlace], [Nationalite], [fatherName], [fatherJob], [adress], [handphone], [homephone], [photo], [status], [InscriptionDate], [Registrationfees], [Monthlyfees], c.LabelC, sy.SchoolYear, f.labelFiliere, n.LabelNivau FROM[dbo].[tblStudent] S Inner join Classes C on c.idClass = s.classID JOIN tblFiliere f on f.idFiliere = c.idFiliere JOIN tblNivau N on n.idNiveau = f.idNiveau Join tblschoolYear sy on sy.idyear = s.idYear WHERE [NumInscription] ='" + FGestionDesEtudiant.Num + "'", con);
                da.Fill(ds, "tblStudent");

                DataTable dt = new DataTable();
                da.Fill(dt);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource source = new ReportDataSource("DataSet1", dt);
                ReportDataSource source1 = new ReportDataSource("DataSet2", dt);
                ReportDataSource source2 = new ReportDataSource("DataSet3", dt);
                ReportDataSource source3 = new ReportDataSource("DataSet4", dt);
                ReportDataSource source4 = new ReportDataSource("DataSet5", dt);
                reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.LocalReport.DataSources.Add(source1);
                reportViewer1.LocalReport.DataSources.Add(source2);
                reportViewer1.LocalReport.DataSources.Add(source3);
                reportViewer1.LocalReport.DataSources.Add(source4);
                reportViewer1.RefreshReport();
                this.reportViewer1.RefreshReport();
            

            this.reportViewer1.RefreshReport();
        }
    }
}
