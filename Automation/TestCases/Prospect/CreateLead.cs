/*
* Project Name: 
* Module Name: 
* Company: 
* Author: 
* Date: 
* Last Modified: 
* Description: 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BossAT.Utils;
using BossAT.Classes;
using System.Security.Permissions;
using NUnit.Framework;

namespace BossAT.TestCases.Admin
{
    [TestFixture]
    public class Lead : ReportsGeneration 
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
            objCommon.clickElement("name", "CompanyName", aTConfigurations.Prospect.CompanyName+Random);
            objCommon.clickElement("name", "ContactName", aTConfigurations.Prospect.ContactName+Random);
            objCommon.clickElement("name", "ContactTitle", aTConfigurations.Prospect.ContactTitle+Random);
            objCommon.clickElement("name", "ContactNumber", aTConfigurations.Prospect.ContactNo);
            objCommon.clickElement("name", "AlternateContactNumber", aTConfigurations.Prospect.AlternateContactNo);
            objCommon.clickElement("name", "ExtensionNumber", aTConfigurations.Prospect.ExtensionNo);
            objCommon.clickElement("name", "Email", aTConfigurations.Prospect.ContactEmail);
            objCommon.clickElement("name", "Website", aTConfigurations.Prospect.Website);
            objCommon.clickElement("name", "LinkedIn", aTConfigurations.Prospect.CompanyLinkedIn);
            objCommon.clickElement("name", "Industry", aTConfigurations.Prospect.Industry);
            objCommon.clickElement("name", "Address1", aTConfigurations.Prospect.Address1);
            objCommon.clickElement("name", "Address2", aTConfigurations.Prospect.Address2);
            objCommon.clickElement("name", "Country", aTConfigurations.Prospect.Country);
            objCommon.clickElement("name", "State", aTConfigurations.Prospect.State);
            objCommon.clickElement("name", "City", aTConfigurations.Prospect.City);
            objCommon.clickElement("name", "ZIPCode", aTConfigurations.Prospect.ZipCode);

            objCommon.clickElement("xpath", "(//span[text()='Select Time Zone'])[1]");
            objCommon.clickElement("xpath", "(//input[@aria-label='Search'])[1]", aTConfigurations.Prospect.TimeZone);
            objCommon.clickElement("xpath", "//span[text()='(GMT+05:30) Chennai, Kolkata, Mumbai, New Delhi']");

            objCommon.clickElement("xpath", "//span[text()='Select Company Size']");
            objCommon.clickElement("xpath", "(//input[@aria-label='Search'])[2]", aTConfigurations.Prospect.CompanySize);
            objCommon.clickElement("xpath", "//span[text()='1-10']");

//            objCommon.clickElement("xpath", "(//span[text()='Select Executive'])[1]");
//            objCommon.fillTextArea("xpath", "(//input[@aria-label='Search'])[3]", aTConfigurations.Prospect.Executive);
//            objCommon.clickElement("xpath", "//span[text()='Babu']");

            objCommon.clickElement("name", "Source", aTConfigurations.Prospect.Source);
            objCommon.clickElement("name", "AdditionalInformation", aTConfigurations.Prospect.AdditionalInformation);
            objCommon.clickElement("name", "AditionalName", aTConfigurations.Prospect.AdditionalContactName);
            objCommon.clickElement("name", "AditionalTitle", aTConfigurations.Prospect.AdditionalContactNumber);
            objCommon.clickElement("name", "AditionalNumber", aTConfigurations.Prospect.AdditionalContactTitle);
            objCommon.clickElement("name", "AditionalEmail", aTConfigurations.Prospect.AdditionalEmail);

            objCommon.clickElement("xpath", "//a[@class='btn btn-block btn-warning btn-flat']");
            objCommon.clickElement("xpath", "//input[@value='Create Lead']");
            

        }

        [Test]
        [Category("Prospect")]
        public void LeadCreationWithoutAdditionalContactInfo()
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
            objCommon.clickElement("name", "CompanyName", aTConfigurations.Prospect.CompanyName+Random);
            objCommon.clickElement("name", "ContactName", aTConfigurations.Prospect.ContactName+Random);
            objCommon.clickElement("name", "ContactTitle", aTConfigurations.Prospect.ContactTitle+Random);
            objCommon.clickElement("name", "ContactNumber", aTConfigurations.Prospect.ContactNo);
            objCommon.clickElement("name", "AlternateContactNumber", aTConfigurations.Prospect.AlternateContactNo);
            objCommon.clickElement("name", "ExtensionNumber", aTConfigurations.Prospect.ExtensionNo);
            objCommon.clickElement("name", "Email", aTConfigurations.Prospect.ContactEmail);
            objCommon.clickElement("name", "Website", aTConfigurations.Prospect.Website);
            objCommon.clickElement("name", "LinkedIn", aTConfigurations.Prospect.CompanyLinkedIn);
            objCommon.clickElement("name", "Industry", aTConfigurations.Prospect.Industry);
            objCommon.clickElement("name", "Address1", aTConfigurations.Prospect.Address1);
            objCommon.clickElement("name", "Address2", aTConfigurations.Prospect.Address2);
            objCommon.clickElement("name", "Country", aTConfigurations.Prospect.Country);
            objCommon.clickElement("name", "State", aTConfigurations.Prospect.State);
            objCommon.clickElement("name", "City", aTConfigurations.Prospect.City);
            objCommon.clickElement("name", "ZIPCode", aTConfigurations.Prospect.ZipCode);

            objCommon.clickElement("xpath", "(//span[text()='Select Time Zone'])[1]");
            objCommon.clickElement("xpath", "(//input[@aria-label='Search'])[1]", aTConfigurations.Prospect.TimeZone);
            objCommon.clickElement("xpath", "//span[text()='(GMT+05:30) Chennai, Kolkata, Mumbai, New Delhi']");

            objCommon.clickElement("xpath", "//span[text()='Select Company Size']");
            objCommon.clickElement("xpath", "(//input[@aria-label='Search'])[2]", aTConfigurations.Prospect.CompanySize);
            objCommon.clickElement("xpath", "//span[text()='1-10']");

            //            objCommon.clickElement("xpath", "(//span[text()='Select Executive'])[1]");
            //            objCommon.fillTextArea("xpath", "(//input[@aria-label='Search'])[3]", aTConfigurations.Prospect.Executive);
            //            objCommon.clickElement("xpath", "//span[text()='Babu']");

            objCommon.clickElement("name", "Source", aTConfigurations.Prospect.Source);
            objCommon.clickElement("name", "AdditionalInformation", aTConfigurations.Prospect.AdditionalInformation);

            objCommon.clickElement("xpath", "//a[@class='btn btn-block btn-warning btn-flat']");
            objCommon.clickElement("xpath", "//input[@value='Create Lead']");

        }
        [Test]
        [Category("Prospect")]
        public void LeadCreationViewed()
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
            objCommon.clickElement("name", "CompanyName", aTConfigurations.Prospect.CompanyName+Random);
            objCommon.clickElement("name", "ContactName", aTConfigurations.Prospect.ContactName + Random);
            objCommon.clickElement("name", "ContactTitle", aTConfigurations.Prospect.ContactTitle + Random);
            objCommon.clickElement("name", "ContactNumber", aTConfigurations.Prospect.ContactNo);
            objCommon.clickElement("name", "AlternateContactNumber", aTConfigurations.Prospect.AlternateContactNo);
            objCommon.clickElement("name", "ExtensionNumber", aTConfigurations.Prospect.ExtensionNo);
            objCommon.clickElement("name", "Email", aTConfigurations.Prospect.ContactEmail);
            objCommon.clickElement("name", "Website", aTConfigurations.Prospect.Website);
            objCommon.clickElement("name", "LinkedIn", aTConfigurations.Prospect.CompanyLinkedIn);
            objCommon.clickElement("name", "Industry", aTConfigurations.Prospect.Industry);
            objCommon.clickElement("name", "Address1", aTConfigurations.Prospect.Address1);
            objCommon.clickElement("name", "Address2", aTConfigurations.Prospect.Address2);
            objCommon.clickElement("name", "Country", aTConfigurations.Prospect.Country);
            objCommon.clickElement("name", "State", aTConfigurations.Prospect.State);
            objCommon.clickElement("name", "City", aTConfigurations.Prospect.City);
            objCommon.clickElement("name", "ZIPCode", aTConfigurations.Prospect.ZipCode);

            objCommon.clickElement("xpath", "(//span[text()='Select Time Zone'])[1]");
            objCommon.clickElement("xpath", "(//input[@aria-label='Search'])[1]", aTConfigurations.Prospect.TimeZone);
            objCommon.clickElement("xpath", "//span[text()='(GMT+05:30) Chennai, Kolkata, Mumbai, New Delhi']");

            objCommon.clickElement("xpath", "//span[text()='Select Company Size']");
            objCommon.clickElement("xpath", "(//input[@aria-label='Search'])[2]", aTConfigurations.Prospect.CompanySize);
            objCommon.clickElement("xpath", "//span[text()='1-10']");

            //            objCommon.clickElement("xpath", "(//span[text()='Select Executive'])[1]");
            //            objCommon.fillTextArea("xpath", "(//input[@aria-label='Search'])[3]", aTConfigurations.Prospect.Executive);
            //            objCommon.clickElement("xpath", "//span[text()='Babu']");

            objCommon.clickElement("name", "Source", aTConfigurations.Prospect.Source);
            objCommon.clickElement("name", "AdditionalInformation", aTConfigurations.Prospect.AdditionalInformation);

            objCommon.clickElement("xpath", "//a[@class='btn btn-block btn-warning btn-flat']");
            objCommon.clickElement("xpath", "//input[@value='Create Lead']");
            objCommon.clickElement("xpath", "(//a[text()='Prospect '])[1]");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='Leads']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElementFromTable("id", "tableLeads", aTConfigurations.Prospect.CompanyName + Random, "xpath", "(//a[@title='Follow-up'])[1]");


        }

        [Test]
        [Category("Prospect")]
        public void VerifyBackToListbuttonInLeadPage()
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
            objCommon.clickElement("xpath", "//input[@value='Back To List']");
            objCommon.clickElementFromTable("id", "tableLeads", aTConfigurations.Prospect.CompanyName + Random, "xpath", "(//a[@title='Follow-up'])[1]");
        }
    }
}