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
    interface IProcessedPhotos
    {
         void GetAllStudent(GetAllStudentFromDB G);
    }
}
