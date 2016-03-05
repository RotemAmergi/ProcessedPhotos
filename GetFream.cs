using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Data.Odbc;
using System.Collections;
using System.Threading;
using System.Windows;
using System.Net;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ProcessedPhotos
{

    class GetFream
    {
      
        private string path;
        private string status;
        //static List<FileInfo> files = new List<FileInfo>();
        public GetFream(string pathdir,string stustat)
        {
            path = pathdir;
            status = stustat;
        }
        public GetFream()
        {
            path = pathdir;
            status = stustat;
        }



        public string pathdir
        {
            get { return path; }
            set { path = value; }
        }

        public string stustat
        {
            get { return status; }
            set { status = value; }

        }

        public void GetFreamFromdir()
        {

            path = "C:\\RollcallPIc\\";
            string backupDir = @"C:\TestRollcallPIc";
            // Make a reference to a directory.
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] diArr = di.GetDirectories();
            FileInfo[] fiArr = di.GetFiles("*.jpg", SearchOption.AllDirectories);
            try
            {
                // Get a reference to each directory in that directory.
               

                // Display the names of the directories.
                foreach (DirectoryInfo dri in diArr ) {
                    //Console.WriteLine(dri.Name);
                    using (System.IO.StreamWriter ListDir =
                     new System.IO.StreamWriter(@"C:\Users\rotem\Desktop\student\Finall\Finallproject\ProcessedPhotos\ProcessedPhotos\Logs\ListDir\log.txt", true))
                    {
                        ListDir.WriteLine("From Roll-Call " + " " + DateTime.Now+ Environment.NewLine+dri.Name);

                    }
                }
                //C:\Users\rotem\Desktop\student\Finall\Finallproject\ProcessedPhotos\ProcessedPhotos\Logs\ListFile
                //Get a reference to each file in that directory.
                foreach (FileInfo f in fiArr) {
                    //Console.WriteLine("The size of {0} is {1} bytes.", f.Name, f.Length);
                    using (System.IO.StreamWriter ListFile =
                     new System.IO.StreamWriter(@"C:\Users\rotem\Desktop\student\Finall\Finallproject\ProcessedPhotos\ProcessedPhotos\Logs\ListFile\log.txt", true))
                    {
                        ListFile.WriteLine("From Roll-Call " + " " + DateTime.Now + Environment.NewLine + "The size of {0} is {1} bytes.", f.Name, f.Length);

                    }
                }
                    
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\rotem\Desktop\student\Finall\Finallproject\ProcessedPhotos\ProcessedPhotos\Logs\ReadFromRollcallPIc\log.txt", true))
                    {
                        file.WriteLine("start read " + " From Roll-Call " + " " + DateTime.Now + Environment.NewLine);

                    }
                }
            
            catch (Exception e)
            {
                //write to error to log file
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\rotem\Desktop\student\Finall\Finallproject\ProcessedPhotos\ProcessedPhotos\Logs\ReadFromRollcallPIc\log.txt", true))
                {
                    file.WriteLine(e.Message + " From Roll-Call " + " " + DateTime.Now + Environment.NewLine);

                }
                Console.WriteLine("Directory {0}  \n could not be accessed!!!!", di.FullName);
                return;  
            }

            //Get each folder and check if the folder empty or not and if she not empty so the file copy to another folder
            

            for (var i = 0; i < diArr.Length; ++i)
            {
                if (diArr[i].GetFiles().Length == 0) ; //Console.WriteLine(diArr[i].Name + "Empty");
                else if (diArr[i].GetFiles().Length > 0)
                {
                    //Console.WriteLine(diArr[i].Name + " Not Empty");
                    for (var j = 0; j < fiArr.Length; j++)
                    {
                        //Console.WriteLine("The size of {0} is {1} bytes.", fiArr[j].Name, fiArr[j].Length);
                        File.Copy(Path.Combine(diArr[i].FullName, fiArr[j].Name), Path.Combine(backupDir, fiArr[j].Name), true); ;
                    }
                }
              }


                    ///conection to kiros Api
                    string appId = "59a2a9c8";
                    string appKey = "eb02a53521025bfc8d46ef74f79f4349";
                    var client = new RestClient("https://api.kairos.com");
                    var request = new RestRequest("detect", Method.POST);

                    // automatically makes the request body serialize as JSON
                    request.RequestFormat = DataFormat.Json;
                    request.AddHeader("app_id", appId);
                    request.AddHeader("app_key", appKey);
                     //image Publicly accessible URL or Base64 encoded photo.
                     request.AddBody(new { image = "http://media.kairos.com/kairos-elizabeth.jpg" });
                    //subject_id Defined by you. Is used as an identifier for the face.
                    request.AddBody("subject_id", "subtest1");
                    //gallery_name Defined by you.Is used to identify the gallery.
                    request.AddBody("gallery_name", "gallerytest1");
                    request.AddBody("selector", "SETPOSE");
                    request.AddBody("symmetricFill", "true");


                    var response = client.Execute(request);
                     // handle response however you want, but I'm just going to print it out
                    //Console.WriteLine(response.Content);

                    //  Reading the status from the json
                    JObject o = JObject.Parse(response.Content);
                    Console.WriteLine("Status: " + o["images"][0]["status"]);

        }

    }
}
 
