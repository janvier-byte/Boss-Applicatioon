/*
* Project Name: BossAT
* Module Name: BookingSoW
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

namespace BossAT.TestCases.BBC
{
    [TestFixture]
    public class BookingSoW : ReportsGeneration
    {
        ATConfiguration aTConfigurations = new ATConfiguration();
        Common objCommon;

        [Test]
        [Category("BBC")]
        public void TC_BAS_81()
        {
            /* Verify delete functionality */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.Password);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "(//a[text()='BBC '])[1]");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='Booking']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("id", "a5392");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "(//button[text()='Back to List'])[1]");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("id", "chkAllSoW");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("id", "a5392");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("id", "idtab_2");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//div[text()='Add test 1']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//div[text()='Advanced Diagnostic']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//div[text()='Airtel']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//div[text()='Amazon']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "(//button[text()='Back to List'])[1]");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//td[text()='Yuvi Company']//..//a[@title='Users']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("name", "UserID");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//option[text()='Babu']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("name", "SalesRoleID");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//option[text()='Manager']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//input[@value='Save']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("id", "btncloseModal");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//td[text()='Yuvi Company']//..//span[@class='slider round']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "(//button[contains(text(),'Yes')])[1]");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//td[text()='Yuvi Company']//..//span[@class='slider round']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "(//button[contains(text(),'Yes')])[1]");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "(//th[contains(text(),'Account Name')])[1]");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "(//th[contains(text(),'SoW #')])[1]");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "(//th[contains(text(),'Project Name')])[1]");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "(//th[contains(text(),'Engagement')])[1]");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "(//th[contains(text(),'Total Hrs')])[1]");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "(//th[contains(text(),'Total Value')])[1]");
            objCommon.sleepForSeconds(5);
        }
    }
}
