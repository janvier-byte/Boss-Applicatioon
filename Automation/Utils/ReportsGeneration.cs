using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using BossAT.Classes;
using Newtonsoft.Json;
using OpenQA.Selenium.Firefox;

namespace BossAT.Utils
{
    [SetUpFixture]
    public abstract class ReportsGeneration
    {
        protected ExtentReports _extent;
        protected ExtentTest _test;
        protected static IWebDriver _driver;
        protected string projectPath;
        [OneTimeSetUp]
        protected void Setup()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + "Reports\\ExtentReport_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.LoadConfig(projectPath + @"\Config\extent-config.xml");
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Project Name", "BOSS_AT");
            _extent.AddSystemInfo("Environment", "Testing Environment");
            _extent.AddSystemInfo("Done By", "Kaushik");
           
        }
        [OneTimeTearDown]
        protected void TearDown()
        {
            _extent.Flush();
        }
        [SetUp]
        public void BeforeTest()
        {
            ATConfiguration aTConfiguration = new ATConfiguration();
            aTConfiguration = GetConfiguration();

           string WebDriverPath = projectPath + @"\WebDrivers\chromedriver.exe";

            if (aTConfiguration.WebDriver.ToLower() == "firefox")
            {
                FirefoxDriverService firefoxDriverService = FirefoxDriverService.CreateDefaultService("webdriver.firefox.driver", aTConfiguration.WebDriverPath);
                _driver = new FirefoxDriver(firefoxDriverService);
            }
            else
            {
                ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService("webdriver.chrome.driver", WebDriverPath);
                _driver = new ChromeDriver(chromeDriverService);
            }

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "": string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            String screenShotPath = string.Empty;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" +time.ToString("h_mm_ss") + ".png";
                    screenShotPath = Capture(_driver, fileName);
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            if (logstatus.ToString().Equals("fail", StringComparison.InvariantCultureIgnoreCase))
                _test.Log(logstatus, "Test ended with " + logstatus + "<br />" + stacktrace).AddScreenCaptureFromPath(screenShotPath);
            else
                _test.Log(logstatus, "Test ended with " + logstatus + "<br />" + stacktrace);

            _extent.Flush();
            _driver.Quit();
        }
        public static IWebDriver GetDriver()
        {
            return _driver;
        }
        public static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Screenshots\\" +screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }

        public ATConfiguration GetConfiguration()
        {
            string configFilePath = string.Empty;
            ATConfiguration aTConfigurations = new ATConfiguration();

            configFilePath = projectPath + "Config\\config.json";

            using (StreamReader r = new StreamReader(configFilePath))
            {
                string json = r.ReadToEnd();
                aTConfigurations = JsonConvert.DeserializeObject<ATConfiguration>(json);
            }

            return aTConfigurations;
        }
    }
}