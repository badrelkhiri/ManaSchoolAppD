using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SchoolManagment3.DAL;

namespace SchoolManagment3.BL
{
    class Class_student
    {
        public static DataTable Ps_GetFilierByNivau(int id)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Ps_GetFilierByNivau", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.BigInt, id));
            return dt;
        }


        public static DataTable Ps_GetClassByFiliere(int id, int idYear)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Ps_GetClassByFiliere", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.BigInt, id),
                DataAccessLayer.CreateParameter("@idYear", SqlDbType.BigInt, idYear));
            return dt;
        }
        public static int PS_addStudent(string NumInscription, string FullName,
            string Gender, DateTime birthday, string birthPlace, string Nationalite, string fatherName,
            string fatherJob, string adress, string handphone, string homephone, byte[] photo, bool status, 
            DateTime InscriptionDate, decimal Registrationfees, decimal Monthlyfees, int classID, int idyear)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("PS_addStudent", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@NumInscription", SqlDbType.NVarChar, NumInscription),
                DataAccessLayer.CreateParameter("@FullName", SqlDbType.NVarChar, FullName),
                DataAccessLayer.CreateParameter("@Gender", SqlDbType.NVarChar, Gender),
                DataAccessLayer.CreateParameter("@birthday", SqlDbType.Date, birthday),
                DataAccessLayer.CreateParameter("@birthPlace", SqlDbType.NVarChar, birthPlace),
                DataAccessLayer.CreateParameter("@Nationalite", SqlDbType.NVarChar, Nationalite),
                DataAccessLayer.CreateParameter("@fatherName", SqlDbType.NVarChar, fatherName),
                DataAccessLayer.CreateParameter("@fatherJob", SqlDbType.NVarChar, fatherJob),
                DataAccessLayer.CreateParameter("@adress", SqlDbType.NVarChar, adress),
                DataAccessLayer.CreateParameter("@handphone", SqlDbType.NVarChar, handphone),
                DataAccessLayer.CreateParameter("@homephone", SqlDbType.NVarChar, homephone),
                DataAccessLayer.CreateParameter("@photo", SqlDbType.Image, photo),
                DataAccessLayer.CreateParameter("@status", SqlDbType.Bit, status),
                DataAccessLayer.CreateParameter("@InscriptionDate", SqlDbType.DateTime, InscriptionDate),
                DataAccessLayer.CreateParameter("@Registrationfees", SqlDbType.Decimal, Registrationfees),
                DataAccessLayer.CreateParameter("@Monthlyfees", SqlDbType.Decimal, Monthlyfees),
                DataAccessLayer.CreateParameter("@classID", SqlDbType.BigInt, classID),
                DataAccessLayer.CreateParameter("@idyear", SqlDbType.BigInt, idyear)
                );
            DataAccessLayer.Close();
            return count;
        }

        public static int usp_tblStudentUpdate(string NumInscription, string FullName,
            string Gender, DateTime birthday, string birthPlace, string Nationalite, string fatherName,
            string fatherJob, string adress, string handphone, string homephone, byte[] photo, bool status,
            DateTime InscriptionDate, decimal Registrationfees, decimal Monthlyfees, int classID, int idyear)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblStudentUpdate", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@NumInscription", SqlDbType.NVarChar, NumInscription),
                DataAccessLayer.CreateParameter("@FullName", SqlDbType.NVarChar, FullName),
                DataAccessLayer.CreateParameter("@Gender", SqlDbType.NVarChar, Gender),
                DataAccessLayer.CreateParameter("@birthday", SqlDbType.Date, birthday),
                DataAccessLayer.CreateParameter("@birthPlace", SqlDbType.NVarChar, birthPlace),
                DataAccessLayer.CreateParameter("@Nationalite", SqlDbType.NVarChar, Nationalite),
                DataAccessLayer.CreateParameter("@fatherName", SqlDbType.NVarChar, fatherName),
                DataAccessLayer.CreateParameter("@fatherJob", SqlDbType.NVarChar, fatherJob),
                DataAccessLayer.CreateParameter("@adress", SqlDbType.NVarChar, adress),
                DataAccessLayer.CreateParameter("@handphone", SqlDbType.NVarChar, handphone),
                DataAccessLayer.CreateParameter("@homephone", SqlDbType.NVarChar, homephone),
                DataAccessLayer.CreateParameter("@photo", SqlDbType.Image, photo),
                DataAccessLayer.CreateParameter("@status", SqlDbType.Bit, status),
                DataAccessLayer.CreateParameter("@InscriptionDate", SqlDbType.DateTime, InscriptionDate),
                DataAccessLayer.CreateParameter("@Registrationfees", SqlDbType.Decimal, Registrationfees),
                DataAccessLayer.CreateParameter("@Monthlyfees", SqlDbType.Decimal, Monthlyfees),
                DataAccessLayer.CreateParameter("@classID", SqlDbType.BigInt, classID),
                DataAccessLayer.CreateParameter("@idyear", SqlDbType.BigInt, idyear)
                );
            DataAccessLayer.Close();
            return count;
        }

        public static int usp_tblStudentDelete(string NumInscription)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblStudentDelete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@NumInscription", SqlDbType.NVarChar, NumInscription));
            DataAccessLayer.Close();
            return count;
        }

        public static DataTable usp_tblStudentSelect()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_tblStudentSelect", CommandType.StoredProcedure);
            return dt;
        }

        public static DataTable usp_tblStudentSelectByName(string search)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_tblStudentSelectByName", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@search", SqlDbType.NVarChar, search));
            return dt;
        }

        public static DataTable usp_tblStudentSelectByNumber(string number)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_tblStudentSelectByNumber", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@NumInscription", SqlDbType.NVarChar, number));
            return dt;
        }
        public static DataTable Usp_SearchStudentbyClass(int classe)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Usp_SearchStudentbyClass", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idClass", SqlDbType.BigInt, classe));
            return dt;
        }

        public static DataTable Usp_SearchStudentbyDate(DateTime dateBegin, DateTime dateEnd)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Usp_SearchStudentbyDate", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@dateBegin", SqlDbType.DateTime, dateBegin),
                DataAccessLayer.CreateParameter("@dateEnd", SqlDbType.DateTime, dateEnd));
            return dt;
        }

        public static DataTable usp_GetStudentByID(string number)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_GetStudentByID", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@NumInscription", SqlDbType.NVarChar, number));
            return dt;
        }
    }
}
