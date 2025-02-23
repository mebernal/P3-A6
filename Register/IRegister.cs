﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Register
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRegister
    {

        [OperationContract]
        string firstName(string fName);
        [OperationContract]
        string lastName(string lName);
        [OperationContract]
        string gradHs(string f, string l, string yesOrno);
    }
}
