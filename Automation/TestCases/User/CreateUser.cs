/*
* Project Name: BossAT
* Module Name: Login
* Company: TAG PVT LTD
* Author: 
* Date: 
* Last Modified: 
* Description: 
*/
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BossAT.Utils;
using BossAT.Classes;
using System.Security.Permissions;

namespace BossAT.TestCases.User
{
    [TestFixture]
    public class CreateUser : ReportsGeneration
    {
        ATConfiguration aTConfigurations = new ATConfiguration();
        Common objCommon;

        [Test]
        [Category("User")]
        public void TC_BAS_35()
        {
            /* Verify if user page is navigated successfully */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.Password);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='User']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='New User']");
            objCommon.sleepForSeconds(5);
        }

        [Test]
        [Category("User")]
        public void TC_BAS_36()
        {
            /* Verify create user functionality with report access */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.Password);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='User']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='New User']");
            objCommon.sleepForSeconds(5);
            objCommon.fillTextBox("id", "FirstName", aTConfigurations.TC_BAS_36.FirstName); 
            objCommon.sleepForSeconds(5);
            objCommon.fillTextBox("id", "LastName", aTConfigurations.TC_BAS_36.LastName);
            objCommon.sleepForSeconds(5);
            objCommon.fillTextBox("id", "EmailID", aTConfigurations.TC_BAS_36.Email);
            objCommon.sleepForSeconds(5);
            objCommon.changeDropdown("id", "TeamID", "value", "1");
            objCommon.sleepForSeconds(5);
            objCommon.changeDropdown("id", "AppRoleId","value","1");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("class", "fstNoneSelected");
            objCommon.sleepForSeconds(2);
            //string MNewSeal = string.Format("//span[text()='{0}']", "TAI")
            //string MNewSeal = string.Format("//span[text()='{0}']", "TAI");
            objCommon.clickElement("xpath", "//span[text()='TAI']");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("xpath", "//span[text()='TAG']");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("xpath", "//label[text()='Team Data Access']//..//div[@class='fstElement form-control fstMultipleMode fstNoneSelected']");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("xpath", "//label[text()='Team Data Access']//..//span[text()='SuperAdmin'] ");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("xpath", "//label[text()='Team Data Access']//..//span[text()='Management'] ");
            objCommon.sleepForSeconds(2);
            objCommon.changeDropdown("id", "ImmediateReport", "value", "1");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("id", "IsReportingManager"); 
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("id", "IsAllowWebAccess");
            objCommon.sleepForSeconds(2);
            objCommon.changeDropdown("id", "DashBoardAccessID", "value", "1");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("id", "all_IsIncluded");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("id", "all_AlertRequired");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("name", "Create");
            objCommon.sleepForSeconds(2);
        }

        [Test]
        [Category("User")]
        public void TC_BAS_37()
        {
            /* Verify create user functionality without report access section */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.Password);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='User']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='New User']");
            objCommon.sleepForSeconds(5);
            objCommon.fillTextBox("id", "FirstName", aTConfigurations.TC_BAS_36.FirstName);
            objCommon.sleepForSeconds(5);
            objCommon.fillTextBox("id", "LastName", aTConfigurations.TC_BAS_36.LastName);
            objCommon.sleepForSeconds(5);
            objCommon.fillTextBox("id", "EmailID", aTConfigurations.TC_BAS_36.Email);
            objCommon.sleepForSeconds(5);
            objCommon.changeDropdown("id", "TeamID", "value", "1");
            objCommon.sleepForSeconds(5);
            objCommon.changeDropdown("id", "AppRoleId", "value", "1");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("class", "fstNoneSelected");
            objCommon.sleepForSeconds(2);
            //string MNewSeal = string.Format("//span[text()='{0}']", "TAI")
            //string MNewSeal = string.Format("//span[text()='{0}']", "TAI");
            objCommon.clickElement("xpath", "//span[text()='TAI']");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("xpath", "//span[text()='TAG']");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("xpath", "//label[text()='Team Data Access']//..//div[@class='fstElement form-control fstMultipleMode fstNoneSelected']");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("xpath", "//label[text()='Team Data Access']//..//span[text()='SuperAdmin'] ");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("xpath", "//label[text()='Team Data Access']//..//span[text()='Management'] ");
            objCommon.sleepForSeconds(2);
            objCommon.changeDropdown("id", "ImmediateReport", "value", "1");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("id", "IsReportingManager");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("id", "IsAllowWebAccess");
            objCommon.sleepForSeconds(2);
            objCommon.changeDropdown("id", "DashBoardAccessID", "value", "1");
            objCommon.sleepForSeconds(2);
            //objCommon.clickElement("id", "all_IsIncluded");
            //objCommon.sleepForSeconds(2);
            //objCommon.clickElement("id", "all_AlertRequired");
            //objCommon.sleepForSeconds(2);
            objCommon.clickElement("name", "Create");
            objCommon.sleepForSeconds(2);
        }

        [Test]
        [Category("User")]
        public void TC_BAS_39()
        {
            /* Verify Back To List button functionality */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.Password);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='User']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='New User']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//button[contains(text(),'Back to List')]");
            objCommon.sleepForSeconds(2);
        }
    }
}
