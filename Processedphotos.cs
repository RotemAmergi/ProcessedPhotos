using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.Common;
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Data.Odbc;
using System.Collections;
using System.Threading;


namespace ProcessedPhotos
{
    class Processedphotos : IProcessedPhotos
    {
      

        public void GetAllStudent(GetAllStudentFromDB getAllStudentFromDB)
        {
            
            Dictionary<String, StudentStruct> student = new Dictionary<String, StudentStruct>();

            ///conection to DB
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "server=localhost;uid=testuser;" + "pwd=12345;database=student;";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
          

            try
            {
                //This part belong to the way to read a data from mysql into the imageFromDB
                conn.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT studentFullname,idNumber FROM studentlist";
                MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
              //  int count = reader.FieldCount;
                DataTable dtCustomers = new DataTable();
                dtCustomers.Load(reader);
                foreach (DataRow row in dtCustomers.Rows)
                {
                    StudentStruct s = new StudentStruct();
                    s.Name = row["studentFullname"].ToString();
                    s.Id = Convert.ToDouble(row["idNumber"].ToString());
                    s.attendance = "Not present";
                    student.Add(s.Name + s.Id,s);
                }
               
                using (System.IO.StreamWriter errorlog =
                    new System.IO.StreamWriter(@"C:\Users\rotem\Desktop\student\Finall\Finallproject\ProcessedPhotos\ProcessedPhotos\Logs\Mysql\log2.txt", true))
                {
                    errorlog.WriteLine("Connection Succeful From Roll-Call " + "  " + DateTime.Now + Environment.NewLine);

                }
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //write to error to log file
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\rotem\Desktop\student\Finall\Finallproject\ProcessedPhotos\ProcessedPhotos\Logs\Mysql\log.txt", true))
                {
                    file.WriteLine(ex.Message + " From Roll-Call " + " " + DateTime.Now + Environment.NewLine);

                }
            }
            conn.Close();
            getAllStudentFromDB(new GetAllStudentToStrucet(student));
        }
    }
}
