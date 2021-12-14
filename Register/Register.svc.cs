using System;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace Register
{
    public class Service1 : IRegister
    {
        string emailID;
        int num;
        int id;
        string email;
        string sId;
        /*Return error if first name string is empty or return it*/
        public string firstName(string fName)
        {
            if (string.IsNullOrEmpty(fName))
            {
                return "First name field must not be empty.";
            }
            return fName;
        }

        public string gradHs(string f, string l, string yesOrno)
        {
            if (yesOrno.Equals("Y")) //If the student has graduated high school then they may successfully register
            {
                Random r = new Random();
                num = r.Next(1,99);
                id = r.Next(12345, 77777);
                email = f[0] + l + num.ToString() + "@ASU.edu"; //Create student email using the first char of first name + last name + a random number
                sId = id.ToString(); //Student ID
                emailID = "Your student email is: " + email + " and your student ID is: " + sId;
                /*Write new student data to XML file called registered.xml stored in the App_Data of the services directory*/
                try
                {
                    string p = Path.Combine(HttpRuntime.AppDomainAppPath, @"obj");
                    XmlTextWriter writer = new XmlTextWriter(p + "/registered.xml", System.Text.Encoding.UTF8);
                    writer.WriteStartDocument(true);
                    writer.Formatting = Formatting.Indented;
                    writer.Indentation = 2;
                    writer.WriteStartElement("Table");
                    crNode(sId, f + " " + l, email, writer);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                } catch (Exception ex)
                {
                    return ex.Message; //More error conditions
                }        
            }
            else
            {
                string regErr = "Please try registering later."; //More error conditions
                return regErr;
            }
            
            return emailID; //If the prospective student registers successfully, then return their new student email and  ID.
        }
        /*Return error if last name field is empty or return it*/
        public string lastName(string lName)
        {
            if (string.IsNullOrEmpty(lName))
            {
                return "Last name field must not be empty.";
            }
            return lName;
        }
        /*Used by the xml writer to write new student info to an xml file*/
        private void crNode(string sID, string sName, string email, XmlTextWriter writer)
        {
            writer.WriteStartElement("Student");
            writer.WriteStartElement("Student_ID");
            writer.WriteString(sID);
            writer.WriteEndElement();
            writer.WriteStartElement("sName");
            writer.WriteString(sName);
            writer.WriteEndElement();
            writer.WriteStartElement("sEmail");
            writer.WriteString(email);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
