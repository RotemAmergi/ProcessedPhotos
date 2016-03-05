using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Data.Odbc;
using System.Collections;
using System.Threading;

namespace ProcessedPhotos
{
    class StudentStruct
    {
        private string name;
        private double ID;
        private string Attendance;

        public StudentStruct(string Name, double Id, string attendance)
        {
            name = Name;
            ID = Id;
            Attendance = attendance;
        }

        public StudentStruct()
        {
            name = Name;
            ID = Id;
            Attendance = attendance;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Id
        {
            get { return ID; }
            set { ID = value; }
        }

        public string attendance{
            
            get { return Attendance; }
            set { Attendance = value; }
        } 
        public string toString()
        {
            return "Student: [Name =" + Name +
                ", ID= " + Id + " ,Attendance= " + Attendance +'\n';
        }

    }
}
   
