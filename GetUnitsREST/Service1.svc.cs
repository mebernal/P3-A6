using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml;

namespace GetUnitsREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetUnits()
        {
            string u = "";
            string URL = "http://localhost:25056/";
            string path = Path.Combine(URL, @"obj"); //Get the path of xml file we want to read from
            XmlDocument doc = new XmlDocument();
            doc.Load(path + "/total_units.xml"); //The xml file we will pull data from
            XmlNodeList units = doc.GetElementsByTagName("Total"); //Get the student id

            for (int i = 0; i < units.Count; i++)
            {
                u = units[i].InnerXml; //Write the student id info from xml to a string
            }

            if (!string.IsNullOrEmpty(u))
            {
                return u;
            }
            return "An error occurred.";
        }
    }
}
