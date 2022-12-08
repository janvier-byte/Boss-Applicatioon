using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Excel.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BossAT.Classes;
using System.Windows.Forms;
using NUnit.Framework;
using System.Windows.Media.TextFormatting;
using System.Threading;

namespace BossAT.Utils
{
    public class Common : ReportsGeneration
    {
        public IWebDriver driver;
        ATConfiguration aTConfigurations = new ATConfiguration();


        public Common(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void goToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void sleepForSeconds(int sec)
        {
            System.Threading.Thread.Sleep(sec * 1000);
        }
        public IWebElement getElement(string by, string uid)
        {
            IWebElement webElement = null;

            if (by.ToLower() == "id")
                webElement = driver.FindElement(By.Id(uid));
            else if (by.ToLower() == "name")
                webElement = driver.FindElement(By.Name(uid));
            else if (by.ToLower() == "class")
                webElement = driver.FindElement(By.ClassName(uid));
            else if (by.ToLower() == "xpath")
                webElement = driver.FindElement(By.XPath(uid));

            return webElement;
        }
        public IList<IWebElement> getElements(string by, string uid)
        {
            IList<IWebElement> webElement = null;

            if (by.ToLower() == "id")
                webElement = driver.FindElements(By.Id(uid));
            else if (by.ToLower() == "name")
                webElement = driver.FindElements(By.Name(uid));
            else if (by.ToLower() == "class")
                webElement = driver.FindElements(By.ClassName(uid));

            return webElement;
        }

        internal void fillTextBox(string v1, string v2, object bookingHours)
        {
            throw new NotImplementedException();
        }

        internal void ClickElement(string v1, string v2, object id_bookingdate)
        {
            throw new NotImplementedException();
        }

        public IWebElement getElementByXPath(string xPath)
        {
            IWebElement webElement = null;
            webElement = driver.FindElement(By.XPath(xPath));
            return webElement;
        }

        internal void clickElement(string v1, string v2, object userID)
        {
            throw new NotImplementedException();
        }

        public IWebElement getElementByCssSelector(string cssSelector)
        {
            IWebElement webElement = null;
            webElement = driver.FindElement(By.CssSelector(cssSelector));
            return webElement;
        }

        public void clickElementFromTable(string tableBy, string tableUid, string matchingText, string linkBy, string linkUid)
        {
            //To fetch the table and it's rows
            IWebElement tableElement = getElement(tableBy, tableUid);
            List<IWebElement> rowElements;

            if (tableBy.ToLower() == "id")
            {
                rowElements = new List<IWebElement>(tableElement.FindElements(By.XPath("//table[@id='" + tableUid + "']/tbody/tr")));
            }
            else if (tableBy.ToLower() == "name")
            {
                rowElements = new List<IWebElement>(tableElement.FindElements(By.XPath("//table[@name='" + tableUid + "']/tbody/tr")));
            }
            else if (tableBy.ToLower() == "class")
            {
                rowElements = new List<IWebElement>(tableElement.FindElements(By.XPath("//table[@class='" + tableUid + "']/tbody/tr")));
            }
            else
            {
                rowElements = new List<IWebElement>(tableElement.FindElements(By.XPath(tableUid + "/tbody/tr")));
            }
            bool eleFound = false;

            if (rowElements.Count() > 0)
            {
                foreach (var row in rowElements)
                {
                    List<IWebElement> colElements = new List<IWebElement>(row.FindElements(By.TagName("td")));

                    if (colElements.Count > 0)
                    {
                        foreach (var col in colElements)
                        {
                            if (col.Text.Trim().ToLower() == matchingText.Trim().ToLower())
                            {
                                eleFound = true;

                                if (linkBy.ToLower() == "id")
                                    row.FindElement(By.Id(linkUid)).Click();
                                else if (linkBy.ToLower() == "name")
                                    row.FindElement(By.Name(linkUid)).Click();
                                else if (linkBy.ToLower() == "class")
                                    row.FindElement(By.ClassName(linkUid)).Click();
                                else if (linkBy.ToLower() == "xpath")
                                    row.FindElement(By.XPath(linkUid)).Click();
                                break;
                            }
                        }
                    }

                    if (eleFound)
                        break;
                }
            }
        }
        //To fill text box based on it's selector type
        public void fillTextBox(string by, string uid, string val)
        {
            var eleTextBox = getElement(by, uid);
            eleTextBox.Clear();
            eleTextBox.SendKeys(val);
        }
        //To fill text area based on it's selector type
        public void clickElement(string by, string uid, string val)
        {
            var eleTextArea = getElement(by, uid);
            eleTextArea.Clear();
            eleTextArea.SendKeys(val);
        }
        //To fill text editor based on it's selector type
        public void fillTextEditor(string frameBy, string frameUid, string val)
        {
            var eleTextEditorFrame = getElement(frameBy, frameUid);
            driver.SwitchTo().Frame(eleTextEditorFrame);
            IWebElement bodyElement = driver.FindElement(By.TagName("body"));
            bodyElement.Clear();
            bodyElement.SendKeys(val);
            resetFrame();
            changeFrame("name", "main");
        }
        //To change frop-down based on it's selector type
        public void changeDropdown(string selBy, string selUid, string optBy, string val)
        {
            SelectElement selectElement = new SelectElement(getElement(selBy, selUid));

            if (optBy.ToLower() == "index")
                selectElement.SelectByIndex(Convert.ToInt32(val));
            else if (optBy.ToLower() == "value")
                selectElement.SelectByValue(val);
            else
                selectElement.SelectByText(val);
        }
        //To select radio button based on it's selector type
        public void selectRadioOrCheckbox(string by, string uid, string val)
        {
            IList<IWebElement> radioElement = getElements(by, uid);

            for (int i = 0; i < radioElement.Count; i++)
            {
                // Store the checkbox name to the string variable, using 'Value' attribute
                if (radioElement.ElementAt(i).GetAttribute("value").Equals(val))
                {
                    radioElement.ElementAt(i).Click();
                    break;
                }
            }
        }
        //To upload documents based on it's selector type
        public void uploadDocument(string by, string uid, string documentPath)
        {
            var uploadElement = getElement(by, uid);

            // enter the file path onto the file-selection input field
            uploadElement.SendKeys(documentPath);
        }
        public void ConfirmAlert(bool decision)
        {
            IAlert alert = driver.SwitchTo().Alert();

            if (decision)
                alert.Accept();
            else
                alert.Dismiss();
        }
        public string GetDocumentMethod(string docMethod)
        {
            string retVal = string.Empty;
            if (docMethod.ToLower() == "individual upload")
                retVal = "1";
            else if (docMethod.ToLower() == "bulk upload")
                retVal = "2";
            else
                retVal = "3";

            return retVal;
        }
        #region Click Events
        public void clickElement(string by, string uid)
        {
            getElement(by, uid).Click();
        }
        public void clickElementWithTitle(string by, string uid, bool isLast)
        {
            if (isLast)
                driver.FindElement(By.XPath("//*[@title = '" + uid + "'][last()]")).Click();
            else
                driver.FindElement(By.XPath("//*[@title = '" + uid + "']")).Click();
        }
        public void selectFolderTree(string folderName)
        {
            driver.FindElement(By.XPath("//li/a[contains(text(),'" + folderName + "')]")).Click();
        }
        #endregion

        #region Frame Events
        public void changeFrame(string by, string uid)
        {
            if (by.ToLower() == "id")
                driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("[id = '" + uid + "']")));
            else if (by.ToLower() == "name")
                driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("[name = '" + uid + "']")));
            else if (by.ToLower() == "xpath")
                driver.SwitchTo().Frame(driver.FindElement(By.XPath(uid)));
        }
        public void resetFrame()
        {
            driver.SwitchTo().DefaultContent();
        }
        public void navigateToHeaderMenu(string menuItem)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("[name = 'header']")));

            if (menuItem != "")
                driver.FindElement(By.XPath("//*[@id='" + menuItem + "']")).Click();
        }
        public void navigateToFooterMenu(string menuItem)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("[name = 'footer']")));
            driver.FindElement(By.XPath("//*[@id='" + menuItem + "']")).Click();
        }
        #endregion

        public Boolean verifyPageLoaded(string xPath)
        {
            Boolean res = driver.FindElement(By.XPath(xPath)).Displayed;
            return res;
        }
        public Boolean verifySuccessMessage(string by, string uid, string val)
        {
            Boolean res = false;
            try
            {
                if (String.Compare(getElement(by, uid).GetAttribute("innerHTML"), val, true) == 0)
                    res = true;
                else
                    res = false;
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }
        public void closeBrowser()
        {
            driver.Quit();
        }

        public ATConfiguration getConfig()
        {
            string configFilePath = string.Empty;
            ATConfiguration aTConfigurations = new ATConfiguration();

            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            configFilePath = projectPath + "Config\\config.json";

            using (StreamReader r = new StreamReader(configFilePath))
            {
                string json = r.ReadToEnd();
                aTConfigurations = JsonConvert.DeserializeObject<ATConfiguration>(json);
            }

            return aTConfigurations;
        }//Datepicker
        public void DatePickerCalendar(string Date, string Month, string Year)
        {
            string target_year = Year;
            string target_month = Month;
            string target_date = Date;

            string space = " ";



            string target_month_year_string = target_month + space + target_year;



            string selected_year_string = getElement("class", "ui-datepicker-year").GetAttribute("innerHTML");



            string selected_month_string = getElement("class", "ui-datepicker-month").GetAttribute("innerHTML");



            string selected_month_year_string = selected_month_string + space + selected_year_string;



            if (selected_month_year_string != target_month_year_string)
            {
                if ((Int32.Parse(target_year)) < (Int32.Parse(selected_year_string)))
                {
                    while (selected_month_year_string != target_month_year_string)
                    {
                        clickElement("xpath", "//*[@id=\'ui-datepicker-div\']/div/a[1]");
                        selected_year_string = getElement("class", "ui-datepicker-year").GetAttribute("innerHTML");



                        selected_month_string = getElement("class", "ui-datepicker-month").GetAttribute("innerHTML");




                        selected_month_year_string = selected_month_string + space + selected_year_string;



                    }



                    clickElement("xpath", "//td[not(contains(@class,'ui-datepicker-other-month'))]/a[text()='" + target_date + "']");



                    sleepForSeconds(3);
                    clickElement("xpath", "//button[@class='ui-datepicker-close ui-state-default ui-priority-primary ui-corner-all']");
                    sleepForSeconds(3);



                }
                else
                {

                    while (selected_month_year_string != target_month_year_string)
                    {
                        clickElement("xpath", "//*[@id=\'ui-datepicker-div\']/div/a[2]");
                        selected_year_string = getElement("class", "ui-datepicker-year").GetAttribute("innerHTML");



                        selected_month_string = getElement("class", "ui-datepicker-month").GetAttribute("innerHTML");



                        selected_month_year_string = selected_month_string + space + selected_year_string;
                    }



                    clickElement("xpath", "//td[not(contains(@class,'ui-datepicker-other-month'))]/a[text()='" + target_date + "']");



                    sleepForSeconds(3);
                    clickElement("xpath", "//button[@class='ui-datepicker-close ui-state-default ui-priority-primary ui-corner-all']");
                    sleepForSeconds(3);
                }



            }
            else
            {



                selected_year_string = getElement("class", "ui-datepicker-year").GetAttribute("innerHTML");



                selected_month_string = getElement("class", "ui-datepicker-month").GetAttribute("innerHTML");




                selected_month_year_string = selected_month_string + space + selected_year_string;



                clickElement("xpath", "//td[not(contains(@class,'ui-datepicker-other-month'))]/a[text()='" + target_date + "']");



                sleepForSeconds(3);
                clickElement("xpath", "//button[@class='ui-datepicker-close ui-state-default ui-priority-primary ui-corner-all']");
                sleepForSeconds(3);



            }
        }

        /* Below function to Find the not visible element */
        public void executeJavascript(string jsString)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript(jsString);
        }

        /* Below function for scroll to view the not visible element */
        public void executeJavascriptScrollToView (string jsString, IWebElement ele)
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            je.ExecuteScript(jsString, ele);
        }

        public void clickDateFromCalander(string tableBy, string tableUid, string matchingText, string linkBy, string linkUid)
        {
            //To fetch the table and it's rows
            IWebElement tableElement = getElement(tableBy, tableUid);
            List<IWebElement> rowElements = new List<IWebElement>(tableElement.FindElements(By.XPath("//table[@id='" + tableUid + "']/tbody/tr")));
            bool eleFound = false;
            if (rowElements.Count() > 0)
            {
                foreach (var row in rowElements)
                {
                    List<IWebElement> colElements = new List<IWebElement>(row.FindElements(By.TagName("td")));

                    if (colElements.Count > 0)
                    {
                        foreach (var col in colElements)
                        {
                            if (col.Text.Trim().ToLower() == matchingText.Trim().ToLower())
                            {
                                eleFound = true;

                                if (linkBy.ToLower() == "id")
                                    row.FindElement(By.Id(linkUid)).Click();
                                else if (linkBy.ToLower() == "name")
                                    row.FindElement(By.Name(linkUid)).Click();
                                else if (linkBy.ToLower() == "class")
                                    row.FindElement(By.ClassName(linkUid)).Click();
                                break;
                            }
                        }
                    }

                    if (eleFound)
                        break;
                }
            }
        }

        /* Below function click the not visible element */
        public void executeJavascriptClick(string by, string uid)
        {
            var eleTextBox = getElement(by, uid);
            String javascript = "arguments[0].click()";
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript(javascript, eleTextBox);
        }

        /* Below function for Verify and validate the message */
        public void assertEqual(string by, string uid, string val)
        {
            var eleTextBox = getElement(by, uid).Text;
            Console.WriteLine("Get Text is:" + eleTextBox);

            try
            {
                Assert.AreEqual(val, eleTextBox);
                Console.WriteLine("Successfull message displayed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        /* Below function for verify and validate the tooltip message */
        public void assertEqualFromAttributeTitle(string by, string uid, string val)
        {
            var eleTextBox = getElement(by, uid);
            string text1 = eleTextBox.GetAttribute("data-title");

            try
            {
                Assert.AreEqual(val, text1);
                Console.WriteLine("Message displayed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        /* Below function for select date in calendar */
        public void datePickerCalendar(string Date, string Month, string Year)
        {
            string target_year = Year;
            string target_month = Month;
            string target_date = Date;

            string space = " ";

            string target_month_year_string = target_month + space + target_year;

            string selected_year_string = getElement("class", "ui-datepicker-year").GetAttribute("innerHTML");

            string selected_month_string = getElement("class", "ui-datepicker-month").GetAttribute("innerHTML");

            string selected_month_year_string = selected_month_string + space + selected_year_string;

            if (selected_month_year_string != target_month_year_string)
            {
                if ((Int32.Parse(target_year)) < (Int32.Parse(selected_year_string)))
                {
                    while (selected_month_year_string != target_month_year_string)
                    {
                        clickElement("xpath", "//*[@id=\'ui-datepicker-div\']/div/a[1]");
                        selected_year_string = getElement("class", "ui-datepicker-year").GetAttribute("innerHTML");

                        selected_month_string = getElement("class", "ui-datepicker-month").GetAttribute("innerHTML");


                        selected_month_year_string = selected_month_string + space + selected_year_string;

                    }

                    clickElement("xpath", "//td[not(contains(@class,'ui-datepicker-other-month'))]/a[text()='" + target_date + "']");

                    sleepForSeconds(3);
                    clickElement("xpath", "//button[@class='ui-datepicker-close ui-state-default ui-priority-primary ui-corner-all']");
                    sleepForSeconds(3);

                }
                else
                {

                    while (selected_month_year_string != target_month_year_string)
                    {
                        clickElement("xpath", "//*[@id=\'ui-datepicker-div\']/div/a[2]");
                        selected_year_string = getElement("class", "ui-datepicker-year").GetAttribute("innerHTML");

                        selected_month_string = getElement("class", "ui-datepicker-month").GetAttribute("innerHTML");

                        selected_month_year_string = selected_month_string + space + selected_year_string;
                    }

                    clickElement("xpath", "//td[not(contains(@class,'ui-datepicker-other-month'))]/a[text()='" + target_date + "']");

                    sleepForSeconds(3);
                    clickElement("xpath", "//button[@class='ui-datepicker-close ui-state-default ui-priority-primary ui-corner-all']");
                    sleepForSeconds(3);
                }

            }
            else
            {

                selected_year_string = getElement("class", "ui-datepicker-year").GetAttribute("innerHTML");

                selected_month_string = getElement("class", "ui-datepicker-month").GetAttribute("innerHTML");


                selected_month_year_string = selected_month_string + space + selected_year_string;

                clickElement("xpath", "//td[not(contains(@class,'ui-datepicker-other-month'))]/a[text()='" + target_date + "']");

                sleepForSeconds(3);
                clickElement("xpath", "//button[@class='ui-datepicker-close ui-state-default ui-priority-primary ui-corner-all']");
                sleepForSeconds(3);

            }
        }

        /* Below function for accept the alert box */
        public void alertBox()
        {
            var alert_win = driver.SwitchTo().Alert();
            alert_win.Accept();
        }

        /* Below function for click plus icon in web table at reference document page */
        public void webTableDataReferenceDocPlusIcon(string by, string uid)
        {

            // To get a row count
            IReadOnlyList<IWebElement> lstTrElem = driver.FindElements(By.XPath("//table[@id='" + uid + "']/tbody/tr"));
            Console.WriteLine("Row count is: " + lstTrElem.Count);

            // To get a column count
            IReadOnlyList<IWebElement> lstTrElem1 = driver.FindElements(By.XPath("//table[@id='" + uid + "']/tbody/tr[1]//td"));
            Console.WriteLine("Column count is: " + lstTrElem1.Count);

            // To get each cell value , every row and column should be iterated.
            for (int rowIncr = 1; rowIncr <= lstTrElem.Count; rowIncr++)
            {

                clickElement("xpath", "//table[@id='" + uid + "']/tbody/tr[" + rowIncr + "]/td[" + 6 + "]/a[1]");
                sleepForSeconds(5);
                clickElement("xpath", "//table[@id='" + uid + "']/tbody/tr[" + rowIncr + "]/td[" + 6 + "]/a[1]");
            }

        }

        //To fill text box based on it's selector type
        public void fillTextBox1(string by, string uid, string val)
        {
            var eleTextBox = getElement(by, uid);
            eleTextBox.SendKeys(val);
        }

        public void callSetup()
        {
            clickElement("id", "lnkSetup");
        }

        public void textBoxClear(string by, string uid)
        {
            var eleTextBox = getElement(by, uid);
            eleTextBox.Clear();
        }

        public void dropDownDefaultOption(string selBy, string selUid)
        {
            SelectElement selectElement = new SelectElement(getElement(selBy, selUid));
            string selectedText = selectElement.SelectedOption.Text;
            Console.WriteLine("Default Option is: " + selectedText);
        }

        public void callDriver()
        {
            //Common objCommon = new Common(GetDriver());
            ATConfiguration aTConfigurations1 = new ATConfiguration();
            aTConfigurations1 = getConfig();
            goToPage(aTConfigurations1.AppUrl1);
        }

        public void pageRefresh()
        {
            driver.Navigate().Refresh();
        }

        public void getMandatoryListItems(string selBy, string selUid)
        {
            IWebElement elt = getElement(selBy, selUid);
            SelectElement s = new SelectElement(elt);
            IList<IWebElement> els = s.Options;
            int e = els.Count;
            for (int j = 0; j < e; j++)
            {
                Console.WriteLine("Option at " + j + " is: " + els.ElementAt(j).Text);
                string optionTXT = els.ElementAt(j).Text;
                if (optionTXT.Equals("No") || optionTXT.Equals("Yes"))
                {
                    Console.WriteLine(optionTXT + " is Verified");
                }
                else
                {
                    Console.WriteLine("Wrong Options");
                }
            }
        }

        /* Below function for Additional fields count */
        public void FieldsCount25(string by, string uid)
        {

            // To get a row count
            IReadOnlyList<IWebElement> lstTrElem = driver.FindElements(By.XPath("//table[@id='" + uid + "']/tbody/tr"));
            Console.WriteLine("Parent Table Row count is: " + lstTrElem.Count);

            // To get a column count
            IReadOnlyList<IWebElement> lstTrElem1 = driver.FindElements(By.XPath("//table[@id='" + uid + "']/tbody/tr[1]//td"));
            Console.WriteLine("Parent Table Column count is: " + lstTrElem1.Count);

            if (lstTrElem.Count == 25)
            {
                Console.WriteLine("Fields count is: " + lstTrElem.Count);
            }
            else
            {
                Console.WriteLine("Fields allowed maximum 25: " + lstTrElem.Count);
            }

        }

        

    }
}