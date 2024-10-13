using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;
using NUnit.Framework;

namespace winapp_visual_tests
{
    public class Tests
    {

        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string CalculatorAppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
        protected static WindowsDriver<WindowsElement> CalculatorSession;
        private static IWebElement CalculatorResult = null;

        [SetUp]
        public void Setup()
        {
            if (CalculatorSession == null)
            {
                Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");

                AppiumOptions options = new AppiumOptions();
                options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
                options.AddAdditionalCapability("deviceName", "WindowsPC");

                var Driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
                CalculatorSession = Driver;
                CalculatorSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
                CalculatorResult = CalculatorSession.FindElementByAccessibilityId("CalculatorResults");

            }
        }

        [Test]
        public void Addition()
        {
            CalculatorSession.FindElementByName("One").Click();
            CalculatorSession.FindElementByName("Plus").Click();
            CalculatorSession.FindElementByName("Seven").Click();
            CalculatorSession.FindElementByName("Equals").Click();
            Assert.AreEqual("8", _GetCalculatorResultText());


        }

        [Test]
        public void Combination()
        {
            CalculatorSession.FindElementByName("Seven").Click();
            CalculatorSession.FindElementByName("Multiply by").Click();
            CalculatorSession.FindElementByName("Nine").Click();
            CalculatorSession.FindElementByName("Plus").Click();
            CalculatorSession.FindElementByName("One").Click();
            CalculatorSession.FindElementByName("Equals").Click();
            CalculatorSession.FindElementByName("Divide by").Click();
            CalculatorSession.FindElementByName("Eight").Click();
            CalculatorSession.FindElementByName("Equals").Click();
            Assert.AreEqual("8", _GetCalculatorResultText());
        }

        [Test]
        public void Division()
        {
            CalculatorSession.FindElementByName("Eight").Click();
            CalculatorSession.FindElementByName("Eight").Click();
            CalculatorSession.FindElementByName("Divide by").Click();
            CalculatorSession.FindElementByName("One").Click();
            CalculatorSession.FindElementByName("One").Click();
            CalculatorSession.FindElementByName("Equals").Click();
            Assert.AreEqual("8", _GetCalculatorResultText());
        }

        [Test]
        public void Multiplication()
        {
            CalculatorSession.FindElementByName("Nine").Click();
            CalculatorSession.FindElementByName("Multiply by").Click();
            CalculatorSession.FindElementByName("Nine").Click();
            CalculatorSession.FindElementByName("Equals").Click();
            Assert.AreEqual("81", _GetCalculatorResultText());
        }

        [Test]
        public void Subtraction()
        {
            CalculatorSession.FindElementByName("Nine").Click();
            CalculatorSession.FindElementByName("Minus").Click();
            CalculatorSession.FindElementByName("One").Click();
            CalculatorSession.FindElementByName("Equals").Click();
            Assert.AreEqual("8", _GetCalculatorResultText());
        }

        protected String _GetCalculatorResultText()
        {
            return CalculatorResult.Text.Replace("Display is", "").Trim();
        }



        [TearDown]
        public static void TearDown()
        {
            // Close the application and delete the session
            if (CalculatorSession != null)
            {
                CalculatorSession.Quit();
                CalculatorSession = null;
            }
            foreach (var process in Process.GetProcessesByName("Calculator"))
            {
                process.Kill();
            }
        }
    }
}
