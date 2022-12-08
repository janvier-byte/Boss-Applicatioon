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
    public class EditUser : ReportsGeneration
    {
        ATConfiguration aTConfigurations = new ATConfiguration();
        Common objCommon;

        [Test]
        [Category("User")]
        public void TC_BAS_40()
        {
            /* Verify edit functionality */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.Password);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='User']");
            objCommon.sleepForSeconds(5);
            objCommon.changeDropdown("name", "tableUser_length", "value","100");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//td[contains(text(),'Kaushik')]//..//a[@title='Edit']");
            objCommon.sleepForSeconds(5);
            objCommon.fillTextBox("id", "FirstName", aTConfigurations.TC_BAS_40.EditedFirstName);
            objCommon.sleepForSeconds(5);
            objCommon.fillTextBox("id", "LastName", aTConfigurations.TC_BAS_40.EditedLastName);
            objCommon.sleepForSeconds(5);
            objCommon.fillTextBox("id", "EmailID", aTConfigurations.TC_BAS_40.EditedEmail);
            objCommon.sleepForSeconds(5);
            objCommon.changeDropdown("id", "TeamID", "value", "1");
            objCommon.sleepForSeconds(5);
            objCommon.changeDropdown("id", "AppRoleId", "value", "1");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("xpath", "//label[text()='Business Unit Access']//..//div[@class='fstControls']");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("xpath", "//label[text()='Business Unit Access']//..//span[text()='TAS'] ");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("xpath", "//label[text()='Team Data Access']//..//div[@class='fstControls']");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("xpath", "//label[text()='Team Data Access']//..//span[text()='SuperAdmin'] ");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("xpath", "//label[text()='Team Data Access']//..//span[text()='Management'] ");
            objCommon.sleepForSeconds(2);
            objCommon.changeDropdown("id", "ImmediateReport", "value", "1");
            objCommon.sleepForSeconds(2);
            //IWebElement ele1 = objCommon.getElement("", "");
            //objCommon.executeJavascriptScroll("arguments[0].scrollIntoView();", ele1);
            objCommon.clickElement("name", "Update");
            objCommon.sleepForSeconds(5);
            objCommon.changeDropdown("name", "tableUser_length", "value", "100");
            objCommon.sleepForSeconds(2);
            objCommon.clickElement("xpath", "//td[contains(text(),'Kaushik_Edit')]//..//a[@title='Edit']");
            objCommon.sleepForSeconds(2);
        }
    }
}
