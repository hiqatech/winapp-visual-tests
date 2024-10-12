using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;
using System.Linq;

namespace winapp_visual_tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");

            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            var driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);

            Thread.Sleep(20000);

            driver.Close();








        }
    }
}