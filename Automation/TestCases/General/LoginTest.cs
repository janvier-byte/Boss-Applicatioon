using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BossAT.Utils;
using BossAT.Classes;

namespace BossAT.TestCases.General
{
    [TestFixture]
    //[Parallelizable]
    public class LoginTest : ReportsGeneration
    {
        ATConfiguration aTConfigurations = new ATConfiguration();
        Common objCommon;
        [Test, TestCaseSource("GetUrls")]
        [Category("Login")]
        public void test_validLogin(string url)
        {
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(url);
            objCommon.fillTextBox("id", "usernamelogin", aTConfigurations.Username);
            objCommon.fillTextBox("id", "passwordlogin", aTConfigurations.Password);
            objCommon.changeDropdown("id", "SelectPage", "Text", aTConfigurations.StartPage);
            objCommon.clickElement("id", "LoginFormSubmit");
            Assert.IsTrue(objCommon.verifyPageLoaded("//frame[@name='header']"));
            objCommon.navigateToHeaderMenu("LogOut");
            objCommon.closeBrowser();
        }

        private static IEnumerable<TestCaseData> GetUrls()
        {
            ATConfiguration aTConfigurations = new ATConfiguration();
            Common objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            yield return new TestCaseData(aTConfigurations.AppUrl1).
                SetName("test_validLogin_url1");
            yield return new TestCaseData(aTConfigurations.AppUrl2).
                SetName("test_validLogin_url2");
        }
    }
}