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
    public class ViewUser : ReportsGeneration
    {
        ATConfiguration aTConfigurations = new ATConfiguration();
        Common objCommon;

        [Test]
        [Category("User")]
        public void TC_BAS_42()
        {
            /* Verify delete functionality */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.Password);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='User']");
            objCommon.sleepForSeconds(5);
            objCommon.changeDropdown("name", "tableUser_length", "value", "100");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//td[contains(text(),'kaushik1')]//..//a[@title='Delete']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//button[contains(text(),'OK')]");
            objCommon.sleepForSeconds(1);
            objCommon.assertEqual("class", "ajs-message", "User deleted successfully!");
            objCommon.sleepForSeconds(1);
        }

        [Test]
        [Category("User")]
        public void TC_BAS_43()
        {
            /* Verify view icon functionality */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.Password);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='User']");
            objCommon.sleepForSeconds(5);
            objCommon.changeDropdown("name", "tableUser_length", "value", "100");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//td[contains(text(),'Kaushik_Edit')]//..//a[@title='Details']");
            objCommon.sleepForSeconds(5);
        }
        [Test]
        [Category("User")]
        public void TC_BAS_44()
        {
            /* Verify UserAccess icon functionality */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.Password);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='User']");
            objCommon.sleepForSeconds(5);
            objCommon.changeDropdown("name", "tableUser_length", "value", "100");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//td[contains(text(),'Kaushik_Edit')]//..//a[@title='User Access']");
            objCommon.sleepForSeconds(5);
        }

    }
}
