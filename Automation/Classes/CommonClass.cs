using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossAT.Classes
{
    public class CommonClass
    {

    }

    public class ATConfiguration
    {
        public string WebDriver { get; set; }
        public string WebDriverPath { get; set; }
        public string AppUrl1 { get; set; }
        public string AppUrl2 { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string StartPage { get; set; }
        public string AttachDocument1 { get; set; }
        public string AttachDocument2 { get; set; }
        public string AttachDocument3 { get; set; }
        public string AttachDocument4 { get; set; }
        public string AttachDocument5 { get; set; }
        public string AttachDocument6 { get; set; }
        public string AttachDocument7 { get; set; }
        public Department_15_Edit Department_15_Edit { get; set; }

        public Prospect Prospect { get; set; }
        public object BBC { get; internal set; }
    }
    public class Department_15_Edit
    {
        public string EditDeptname { get; set; }
    }
    
    public class Prospect
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string ContactNo { get; set; }
        public string AlternateContactNo { get; set; }
        public string ExtensionNo { get; set; }
        public string ContactEmail { get; set; }
        public string Website { get; set; }
        public string CompanyLinkedIn { get; set; }
        public string Industry { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string TimeZone { get; set; }
        public string CompanySize { get; set; }
        public string Executive { get; set; }
        public string Source { get; set; }
        public string AdditionalInformation { get; set; }
        public string AdditionalContactName { get; set; }
        public string AdditionalContactTitle { get; set; }
        public string AdditionalContactNumber { get; set; }
        public string AdditionalEmail { get; set; }









    }
}
