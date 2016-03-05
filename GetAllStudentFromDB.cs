using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data.Odbc;
using System.Collections;
using System.Threading;

namespace ProcessedPhotos
{
    //delegate 
    delegate void GetAllStudentFromDB(GetAllStudentToStrucet reqStudent);
    class GetAllStudentToStrucet
    {
        public Dictionary<string, StudentStruct> Student { get; private set; }
        public GetAllStudentToStrucet(Dictionary<string, StudentStruct> dictionary)
        {
            Student = dictionary;
        }
    }
}
