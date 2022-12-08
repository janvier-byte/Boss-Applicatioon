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

namespace BossAT.TestCases.Login
{
    [TestFixture]
    public class TC_BAS_01_Login : ReportsGeneration
    {
        ATConfiguration aTConfigurations = new ATConfiguration();
        Common objCommon;


        [Test]
        [Category("Login")]
        public void TC_BAS_01_CheckLoginFunctionality()
        {
            /* Verify Login with valid username and password */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.Password);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//*[@id=\"menuList\"]/li[1]/a");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//*[@id=\"menuList\"]/li[1]/ul/li[1]/a");
            objCommon.sleepForSeconds(5);
        }

        [Test]
        [Category("Login")]
        public void TC_BAS_02_CheckLoginFunctionality()
        {
            /* Verify Login with valid username and invalid password */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.TC_BAS_02_CheckLoginFunctionality.InvalidPassword);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(1);
            objCommon.assertEqual("class", "ajs-error", "Invalid password!");
            objCommon.sleepForSeconds(2);
        }

        [Test]
        [Category("Login")]
        public void TC_BAS_03_CheckLoginFunctionality()
        {
            /* Verify Login with invalid username and invalid password */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.TC_BAS_03_CheckLoginFunctionality.InvalidUsername);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.TC_BAS_03_CheckLoginFunctionality.InvalidPassword);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(1);
            objCommon.assertEqual("class", "ajs-error", "Could you run the Boss windows application!");
            objCommon.sleepForSeconds(2);
        }

        [Test]
        [Category("Login")]
        public void TC_BAS_04_CheckLoginFunctionality()
        {
            /* Verify Login with username and without password */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(1);
            objCommon.assertEqual("class", "ajs-error", "Password is required!");
            objCommon.sleepForSeconds(2);
        }

        [Test]
        [Category("Login")]
        public void TC_BAS_05_CheckLoginFunctionality()
        {
            /* Verify Login without username */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            //objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(1);
            objCommon.assertEqual("class", "ajs-error", "Email id is required!");
            objCommon.sleepForSeconds(2);
        }

        [Test]
        [Category("Login")]
        public void TC_BAS_07_CheckLoginFunctionality()
        {
            /* Verify Login without username and password */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            //objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(1);
            objCommon.assertEqual("class", "ajs-error", "Email id is required!");
            objCommon.sleepForSeconds(2);
        }

        [Test]
        [Category("Login")]
        public void TC_BAS_09_CheckLoginFunctionality()
        {
            /* Verify whether change password page navigates successfully */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.Password);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//img[contains(@src,'/Images/profile_user.jpg')]");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='Change Password']");
            objCommon.sleepForSeconds(5);
        }

        [Test]
        [Category("Login")]
        public void TC_BAS_10_CheckLoginFunctionality()
        {
            /* Verify change password functionality successfully */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.Password);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//img[contains(@src,'/Images/profile_user.jpg')]");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='Change Password']");
            objCommon.sleepForSeconds(5); 
            objCommon.fillTextBox("id", "CurrentPassword", aTConfigurations.TC_BAS_10_CheckLoginFunctionality.CurrentPassword);
            objCommon.sleepForSeconds(3);
            objCommon.fillTextBox("id", "NewPassword", aTConfigurations.TC_BAS_10_CheckLoginFunctionality.NewPassword);
            objCommon.sleepForSeconds(3);
            objCommon.fillTextBox("id", "ConfirmPassword", aTConfigurations.TC_BAS_10_CheckLoginFunctionality.ConfirmPassword);
            objCommon.sleepForSeconds(3);
            //objCommon.clickElement("xpath", "//input[@value='Change Password']");
        }

        [Test]
        [Category("Login")]
        public void TC_BAS_13_CheckLoginFunctionality()
        {
            /* Verify the logout functionality */
            objCommon = new Common(GetDriver());
            aTConfigurations = objCommon.getConfig();
            objCommon.goToPage(aTConfigurations.AppUrl1);
            objCommon.fillTextBox("id", "Email", aTConfigurations.Username);
            objCommon.fillTextBox("id", "PasswordHash", aTConfigurations.Password);
            objCommon.clickElement("name", "Login");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//img[contains(@src,'/Images/profile_user.jpg')]");
            objCommon.sleepForSeconds(5);
            objCommon.clickElement("xpath", "//a[text()='Logout']");
            
        }



    }
}
