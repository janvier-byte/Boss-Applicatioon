using BossAT.Classes;
using BossAT.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossAT.TestCases.Prospect
{
    [TestFixture]
    public class ViewLeads : ReportsGeneration
    {
        ATConfiguration aTConfigurations = new ATConfiguration();
        Common objCommon;
        public Random number = new Random();

        [Test]
        [Category("Prospect")]
        public void verifyAscendingDecendingLead()
        {
            // Login 
            objCommon = new Common(GetDriver());
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

            objCommon.clickElement("xpath", "//th[contains(text(),'Company')]");
            objCommon.clickElement("xpath", "//th[contains(text(),'Contact Name')]");
            objCommon.clickElement("xpath", "//th[contains(text(),'Executive')]");
            objCommon.clickElement("xpath", "//th[contains(text(),'State')]");
            objCommon.clickElement("xpath", "//th[contains(text(),'Last Updated')]");
            objCommon.clickElement("xpath", "//th[contains(text(),'Status')]");

        }

        [Test]
        [Category("Prospect")]
        public void verifyAbleToChangeOtherStageLead()
        {
            // Login 
            objCommon = new Common(GetDriver());
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

            objCommon.clickElement("xpath", "(//td[contains(text(),'Techaffinity')])[1]//..//a[@title='Follow-up']");
            //string element = string.Format("(//td[contains(text(),'{0}')])[1]", aTConfigurations.Prospect.CompanyName);
            //objCommon.clickElementFromTable("id", "tableLeads", element, "xpath", "(//a[@title='Follow-up'])[1]");
            objCommon.clickElement("xpath", "(//span[text()='Select TimeZone'])[1]");
            string Timezone = string.Format("//td[contains(text(),'{0}')]", aTConfigurations.Prospect.TimeZone);
            objCommon.clickElement("xpath", Timezone);
            objCommon.clickElement("id", "txtDatetime");
            DateTime date = new DateTime(2022,05,01);
            
            objCommon.fillTextBox("id", "txtDatetime","05/12/2022" );
            objCommon.clickElement("name", "Leadstage");
            objCommon.clickElement("xpath", "//option[text()='Prospecting']");
            objCommon.clickElement("name", "LeadSubStatus");
            objCommon.clickElement("xpath", "//option[text()='Quick Call']");
            objCommon.clickElement("id", "txtMessage", "Testing");
            objCommon.clickElement("xpath", "//input[@class='fstQueryInput fstQueryInputExpanded']");
            objCommon.clickElement("xpath", "//span[text()='Babu M']");
            objCommon.clickElement("xpath", "//label[text()='Users']");
            objCommon.clickElement("xpath", "//button[text()='Save']");

        }

        [Test]
        [Category("Prospect")]
        public void verifyfillterfunctionality()
        {
            objCommon = new Common(GetDriver());
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

            objCommon.clickElement("xpath", "//button[@id='imgHideShow']");
            objCommon.clickElement("name", "TeamName");
            objCommon.clickElement("xpath", "//option[text()='SuperAdmin']");
            objCommon.fillTextBox("id", "Country", "india");
            objCommon.fillTextBox("id", "State", "Tamilnadu");
            objCommon.fillTextBox("id", "City", "Chennai");
            objCommon.fillTextBox("id", "Country", "india");

            objCommon.clickElement("xpath", "//input[@value='Search']");
            objCommon.clickElement("xpath", "//input[@value='Reset']");


        }

     }
}
