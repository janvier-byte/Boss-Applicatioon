using BossAT.Classes;
using BossAT.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossAT.TestCases.My_Catch_Up
{
    [TestFixture]
    class Assignment : ReportsGeneration
    {
        ATConfiguration aTConfigurations = new ATConfiguration();
        Common objCommon;


        [Test]
        [Category("Prospect")]
        public void LeadCreationWithAdditionalContactInfo()
        {
            // Login 
            objCommon = new Common(GetDriver());
            Random number = new Random();
            int Random = number.Next(100, 1000);
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.Password);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "(//a[text()='Prospect '])[1]");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='Leads']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='Create Lead']");
            objCommon.fillTextArea("name", "CompanyName", aTConfigurations.Prospect.CompanyName + Random);
            objCommon.fillTextArea("name", "ContactName", aTConfigurations.Prospect.ContactName + Random);
            objCommon.fillTextArea("name", "ContactTitle", aTConfigurations.Prospect.ContactTitle + Random);
            objCommon.fillTextArea("name", "ContactNumber", aTConfigurations.Prospect.ContactNo);
            objCommon.fillTextArea("name", "AlternateContactNumber", aTConfigurations.Prospect.AlternateContactNo);
            objCommon.fillTextArea("name", "ExtensionNumber", aTConfigurations.Prospect.ExtensionNo);
            objCommon.fillTextArea("name", "Email", aTConfigurations.Prospect.ContactEmail);
            objCommon.fillTextArea("name", "Website", aTConfigurations.Prospect.Website);
            objCommon.fillTextArea("name", "LinkedIn", aTConfigurations.Prospect.CompanyLinkedIn);
            objCommon.fillTextArea("name", "Industry", aTConfigurations.Prospect.Industry);
            objCommon.fillTextArea("name", "Address1", aTConfigurations.Prospect.Address1);
            objCommon.fillTextArea("name", "Address2", aTConfigurations.Prospect.Address2);
            objCommon.fillTextArea("name", "Country", aTConfigurations.Prospect.Country);
            objCommon.fillTextArea("name", "State", aTConfigurations.Prospect.State);
            objCommon.fillTextArea("name", "City", aTConfigurations.Prospect.City);
            objCommon.fillTextArea("name", "ZIPCode", aTConfigurations.Prospect.ZipCode);

            objCommon.clickElement("xpath", "(//span[text()='Select Time Zone'])[1]");
            objCommon.fillTextArea("xpath", "(//input[@aria-label='Search'])[1]", aTConfigurations.Prospect.TimeZone);
            objCommon.clickElement("xpath", "//span[text()='(GMT+05:30) Chennai, Kolkata, Mumbai, New Delhi']");

            objCommon.clickElement("xpath", "//span[text()='Select Company Size']");
            objCommon.fillTextArea("xpath", "(//input[@aria-label='Search'])[2]", aTConfigurations.Prospect.CompanySize);
            objCommon.clickElement("xpath", "//span[text()='1-10']");

            //            objCommon.clickElement("xpath", "(//span[text()='Select Executive'])[1]");
            //            objCommon.fillTextArea("xpath", "(//input[@aria-label='Search'])[3]", aTConfigurations.Prospect.Executive);
            //            objCommon.clickElement("xpath", "//span[text()='Babu']");

            objCommon.fillTextArea("name", "Source", aTConfigurations.Prospect.Source);
            objCommon.fillTextArea("name", "AdditionalInformation", aTConfigurations.Prospect.AdditionalInformation);
            objCommon.fillTextArea("name", "AditionalName", aTConfigurations.Prospect.AdditionalContactName);
            objCommon.fillTextArea("name", "AditionalTitle", aTConfigurations.Prospect.AdditionalContactNumber);
            objCommon.fillTextArea("name", "AditionalNumber", aTConfigurations.Prospect.AdditionalContactTitle);
            objCommon.fillTextArea("name", "AditionalEmail", aTConfigurations.Prospect.AdditionalEmail);

            objCommon.clickElement("xpath", "//a[@class='btn btn-block btn-warning btn-flat']");
            objCommon.clickElement("xpath", "//input[@value='Create Lead']");


        }
    }
}
