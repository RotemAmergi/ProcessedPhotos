using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Data.Odbc;
using System.Collections;
namespace ProcessedPhotos
{
    class Program
    {
        static Dictionary<String, StudentStruct> dictionary;
        static Processedphotos PP = new Processedphotos();
        static GetFream GF = new GetFream();
        
        static void Main(string[] args)
        {

            
                PP.GetAllStudent(new GetAllStudentFromDB(RequestHander));

                Thread t1 = new Thread(new ThreadStart(GF.GetFreamFromdir));
                t1.Start();
                Thread.Sleep(200);
            
           
        }
        static void RequestHander(GetAllStudentToStrucet reqStudent)
        {   
            dictionary = reqStudent.Student;
            foreach (StudentStruct s in dictionary.Values)
            {   //its print the all student
                Console.WriteLine(s.toString());
            }

        }
    }
}
