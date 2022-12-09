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
    public class View_Booking_Accounts_vs_Booking : ReportsGeneration
    {
        ATConfiguration aTConfigurations = new ATConfiguration();
        Common objCommon;

        [Test]
        [Category("BBC")]
        public void TC_BAS_92()
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
            objCommon.clickElement("id", "idtab_2");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//div[contains(text(),'Babu Company ')]");
            objCommon.sleepForSeconds(5);
        }
        [Test]
        [Category("BBC")]
        public void TC_BAS_93()
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
            objCommon.clickElement("id", "idtab_2");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("id", "StartDate");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//tr//td[@class='day']");
            
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("id", "EndDate");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//tr//td[@class='day']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//div//input[@id='IncludeAll']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", " //div//input[@value='Search']");
            objCommon.sleepForSeconds(5);
        }
        [Test]
        [Category("BBC")]
        public void TC_BAS_94()
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
            objCommon.clickElement("id", "idtab_2");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("id", "StartDate");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//tr//td[@class='day']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("id", "EndDate");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//tr//td[@class='day']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//div//input[@id='IsActualPrice']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", " //div//input[@value='Search']");
            objCommon.sleepForSeconds(5);
        }
        [Test]
        [Category("BBC")]
        public void TC_BAS_95()
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
            objCommon.clickElement("id", "idtab_2");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("id", "StartDate");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//tr//td[@class='day']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("id", "EndDate");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//tr//td[@class='day']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//div//input[@id='IncludeAll']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//div//input[@id='IsActualPrice']");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", " //div//input[@value='Search']");
            objCommon.sleepForSeconds(5);
        }
    }
}
    
