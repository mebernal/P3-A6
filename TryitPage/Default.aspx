<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryitPage._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3><u>Student Registration Form</u></h3>
    <div class ="row">
        <div class="col-md-6">
            <p>
               <b>Description:</b> Register to become a student. Once registered you will be given a student email and ID to enroll in courses.
             </p>
             <p><b>Service URL:</b> http://localhost:25056/Register.svc</p>
             <p><b>Operation:</b>firstName(string fName), lastName(string lName), and gradHs(string f, string l, string yesOrno)</p>
             <p><b>Input:</b> Multiple strings.</p>
             <p><b>Output:</b> A string containing student email and ID.</p>
        </div>
    </div>
    <h5><u>Enter first name:</u></h5>
    <div class ="row">
        <div class="col-md-6">
            <asp:TextBox ID="First" runat="server"></asp:TextBox>
        </div>
    </div>
    <h5><u>Enter last name:</u></h5>
    <div class ="row">
        <div class="col-md-6">
            <asp:TextBox ID="Last" runat="server"></asp:TextBox>
        </div>
    </div>
    <h5><u>Did you graduate from high school?</u></h5>
    <div class ="row">
        <div class="col-md-6">
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="-1" Text="Select"></asp:ListItem> 
                <asp:ListItem Value="Y" Text="Y"></asp:ListItem>
                <asp:ListItem Value="N" Text="N"></asp:ListItem>  
            </asp:DropDownList>
        </div>
    </div>
    <h5><u></u></h5>
    <div class ="row">
        <div class="col-md-6">
            <asp:Button ID="RegisterBtn" runat="server" Text="Submit" OnClick="RegisterBtn_Click" />
        </div>
    </div>
    <div class ="row">
        <div class="col-md-6">
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
    </div>
    <div class ="row">
        <div class="col-md-6">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </div>
    <style>
        hr
        {
        height: 2px;
        background-color: #0094ff;
        border: none;
        }
    </style>
    <hr />
    <h3><u>Student Enrollment Form</u></h3>
    <div class ="row">
        <div class="col-md-6">
            <p>
             <b>Description:</b> Verify enrollee has a valid student email or ID before they can add courses.
             </p>
             <p><b>Service URL:</b> http://localhost:25056/Enroll.svc</p>
             <p><b>Operation:</b>emailOrID(string enroll), or totalUnits(int u)</p>
             <p><b>Input:</b> A string.</p>
             <p><b>Output:</b> A string returning status of save to XML.</p>
        </div>
    </div>
    <h5><u>Enter your student email or student ID to begin:</u></h5>
    <div class ="row">
        <div class="col-md-6">
            <asp:TextBox ID="verifyStudent" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class ="row">
        <div class="col-md-6">
            <asp:Button ID="checkValBtn" runat="server" Text="Submit" OnClick="checkValBtn_Click" />
            <asp:Label ID="Label8" runat="server" Text="When your registration status is verified,  you will be able to add courses."></asp:Label>
        </div>
    </div>
    <br />
    <div class ="row">
        <div class="col-md-6">
            <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
    </div>
    <div class = "row">
        <div class="col-md-6">
            <asp:Button ID="add1Btn" runat="server" Text="Add" Enabled="False" BackColor="#FF3300" OnClick="add1Btn_Click" />
            <asp:Label ID="Label4" runat="server" Text="CSE445  3 Units"></asp:Label>
        </div>
    </div>
    <div class = "row">
        <div class="col-md-6">
            <asp:Button ID="add2Btn" runat="server" Text="Add" Enabled="False" BackColor="#FF3300" OnClick="add2Btn_Click" />
            <asp:Label ID="Label5" runat="server" Text="MAT243 - 4 Units"></asp:Label>
        </div>
    </div>
    <div class = "row">
        <div class="col-md-6">
            <asp:Button ID="add3Btn" runat="server" Text="Add" Enabled="False" BackColor="#FF3300" OnClick="add3Btn_Click" />
            <asp:Label ID="Label6" runat="server" Text="ART100 - 2 Units"></asp:Label>
        </div>
    </div>
    <div class = "row">
        <div class="col-md-6">
            <asp:Button ID="add4Btn" runat="server" Text="Add" Enabled="False" BackColor="#FF3300" OnClick="add4Btn_Click" />
            <asp:Label ID="Label7" runat="server" Text="COM300 - 3 Units"></asp:Label>
        </div>
    </div>
    <br />
    <div class = "row">
        <div class="col-md-6">
            <asp:Button ID="saveBtn" runat="server" Text="Save Selections" Enabled="False" OnClick="saveBtn_Click" />
            <asp:Label ID="Label9" runat="server"></asp:Label>
        </div>
    </div>
    <hr />
    <h3><u>Call the RESTful Service and Return Total Units for Enrollee.</u></h3>
    <div class = "row">
        <div class="col-md-6">
            <p>
             <b>Description:</b> Uses the RESTful service to read from an XML file located in http://localhost:25056/obj.
             </p>
             <p><b>Service URL:</b> http://localhost:21026/Service1.svc/GetUnits</p>
             <p><b>Output:</b> A string returning total units.</p>
            <asp:Button ID="TestBtn" runat="server" OnClick="TestBtn_Click" Text="Show your total units" />

            <asp:Label ID="Label10" runat="server"></asp:Label>

        </div>
    </div>
    <br />
</asp:Content>
