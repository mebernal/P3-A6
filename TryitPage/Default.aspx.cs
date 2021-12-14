using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TryitPage
{
    public partial class _Default : Page
    {
        /*Keeping track of accumulated units.*/
        public static class GLOBALS
        {
            public static int UNITS = 0;
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            /*Grab the first, last, and yes or no selection from input and drop down list*/
            Register.RegisterClient rc = new Register.RegisterClient();

            string first = First.Text.ToString();
            string last = Last.Text.ToString();
            string grad = DropDownList1.Text.ToString();
            /*A bunch of conditions to check to make sure all fields and selections are made*/
            if (string.IsNullOrEmpty(first))
            {
                Label1.Text = rc.firstName(first);
            }
            else if (string.IsNullOrEmpty(last))
            {
                Label1.Text = rc.lastName(last);
            }
            else if (grad.Equals("N"))
            {
                Label1.Text = rc.gradHs(first, last, grad);
            }
            else //Give the newly registered student their new email and ID
            {
                Label2.Text = rc.firstName(first) + " " + rc.lastName(last);
                Label1.Text = rc.gradHs(first, last, grad);
            }
        }

        protected void checkValBtn_Click(object sender, EventArgs e)
        {
            /*Verify the enrollee is actually registered first*/
            Enroll.EnrollClient enr = new Enroll.EnrollClient();
            string str = verifyStudent.Text.ToString();
            Label3.Text = enr.emailOrID(str);
            if (!Label3.Text.Equals("ERROR: You did not register - no valid email or id.") && !Label3.Text.Equals(null))
            { //Enable buttons to add classes if they provide valid info
                Label3.Visible = false;
                Enroll.EnrollClient en = new Enroll.EnrollClient();
                en.totalUnits(0);
                GLOBALS.UNITS = 0;
                add1Btn.Enabled = true;
                add2Btn.Enabled = true;
                add3Btn.Enabled = true;
                add4Btn.Enabled = true;
            }
            else //Don't give the unregistered access to these buttons
            {
                add1Btn.Enabled = false;
                add2Btn.Enabled = false;
                add3Btn.Enabled = false;
                add4Btn.Enabled = false;
                saveBtn.Enabled = false;
                Label3.Visible = true;
            }
        }
        /*Buttons to add courses and accumulate units*/
        protected void add1Btn_Click(object sender, EventArgs e)
        {
            GLOBALS.UNITS += 3;
            add1Btn.Enabled = false;
            saveBtn.Enabled = true;
            Label9.Text = GLOBALS.UNITS.ToString();
        }

        protected void add2Btn_Click(object sender, EventArgs e)
        {
            GLOBALS.UNITS += 4;
            add2Btn.Enabled = false;
            saveBtn.Enabled = true;
            Label9.Text = GLOBALS.UNITS.ToString();
        }

        protected void add3Btn_Click(object sender, EventArgs e)
        {
            GLOBALS.UNITS += 2;
            add3Btn.Enabled = false;
            saveBtn.Enabled = true;
            Label9.Text = GLOBALS.UNITS.ToString();
        }

        protected void add4Btn_Click(object sender, EventArgs e)
        {
            GLOBALS.UNITS += 3;
            add4Btn.Enabled = false;
            saveBtn.Enabled = true;
            Label9.Text = GLOBALS.UNITS.ToString();
        }
        /*Pass the total units to the service endpoint*/
        protected void saveBtn_Click(object sender, EventArgs e)
        {
            Enroll.EnrollClient en = new Enroll.EnrollClient();
            Label9.Text = "Saved Successfully.";
            en.totalUnits(GLOBALS.UNITS);
            add1Btn.Enabled = false;
            add2Btn.Enabled = false;
            add3Btn.Enabled = false;
            add4Btn.Enabled = false;
            saveBtn.Enabled = false;
            Label3.Visible = true;
        }

        protected void TestBtn_Click(object sender, EventArgs e)
        {
            Uri baseUri = new Uri("http://localhost:21026/Service1.svc");
            UriTemplate myTemplate = new UriTemplate("GetUnits");
            Uri completeUri = myTemplate.BindByPosition(baseUri);
            WebClient channel = new WebClient();
            byte[] abc = channel.DownloadData(completeUri);
            Stream strm = new MemoryStream(abc);
            DataContractSerializer obj = new DataContractSerializer(typeof(string));
            string units = obj.ReadObject(strm).ToString();
            Label10.Text = "GetUnitsREST has returned: " + units + " Units";
        }
    }
}
