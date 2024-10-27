using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTestCertification.Tests
{
    

    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    internal class SimpleFormTests : LambdaTestSetup
    {
        [Test, TestCase("Windows 10", "Chrome", "128.0")]
        [TestCase("macOS Ventura", "MicrosoftEdge", "127.0")]
        [TestCase("Windows 11", "Firefox", "130.0")]
        [TestCase("Windows 10", "Internet Explorer", "11.0")]
        public void TestScenario1(string platform, string browser, string version)
        {
            driver = InitializeDriver(platform, browser, version);
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/");
            driver.FindElement(By.XPath("//a[normalize-space()='Simple Form Demo']")).Click();

            Assert.IsTrue(driver.Url.Contains("simple-form-demo"), "URL does not contain 'simple-form-demo'!");

            string message = "Welcome to LambdaTest";
            var messageBox = driver.FindElement(By.XPath("//input[@id='user-message']"));
            messageBox.SendKeys(message);

            driver.FindElement(By.XPath("//button[@id='showInput']")).Click();
            var displayedMessage = driver.FindElement(By.XPath("//p[@id='message']")).Text;
            Assert.AreEqual(message, displayedMessage, "The displayed message does not match!");
        }


    }
}
