using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Xml;

namespace Register
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service2.svc or Service2.svc.cs at the Solution Explorer and start debugging.
    public class Service2 : IEnroll
    {
        public string emailOrID(string enroll)
        {
            string elem1 = "";
            string elem2 = "";
            string path = Path.Combine(HttpRuntime.AppDomainAppPath, @"obj"); //Get the path of xml file we want to read from
            XmlDocument doc = new XmlDocument();
            doc.Load(path + "/registered.xml"); //The xml file we will pull data from
            XmlNodeList elemID = doc.GetElementsByTagName("Student_ID"); //Get the student id
            XmlNodeList elemMail = doc.GetElementsByTagName("sEmail"); //Get the student email

            for (int i = 0; i < elemID.Count; i++)
            {
                 elem1 = elemID[i].InnerXml; //Write the student id info from xml to a string
            }

            for (int i = 0; i < elemID.Count; i++)
            {
                elem2 = elemMail[i].InnerXml; //Write the student email from xml to a string
            }

            if (elem1.Length == 5 && elem1 == enroll)
            {
                return elem1;
            }
            else if (elem2.Length > 5 && elem2 == enroll)
            {
                return elem2;
            }

            return "ERROR: You did not register - no valid email or id.";
        }

        public void totalUnits(int u)
        {
            /*Total units pass in that will be written to xml*/
            string convert = u.ToString(); //Convert the int to a string because apparently you can't write an int to xml
            try
            {
                string p = Path.Combine(HttpRuntime.AppDomainAppPath, @"obj"); //Path of xml file
                XmlTextWriter writer = new XmlTextWriter(p + "/total_units.xml", System.Text.Encoding.UTF8);  //xml file name
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("Table");
                crNode(convert, writer);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
            catch
            {
                
            }
        }
        //XML element format
        private void crNode(string x, XmlTextWriter writer)
        {
            writer.WriteStartElement("Units");
            writer.WriteStartElement("Total");
            writer.WriteString(x);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
