using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTestCertification.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    internal class SliderTest : LambdaTestSetup
    {

        [Test, TestCase("Windows 10", "Chrome", "128.0")]
        [TestCase("macOS Ventura", "MicrosoftEdge", "127.0")]
        [TestCase("Windows 11", "Firefox", "130.0")]
        [TestCase("Windows 10", "Internet Explorer", "11.0")]
        public void DragSliderTo95(string platform, string browser, string version)
        {
            driver = InitializeDriver(platform, browser, version);
            // Step 1: Navigate to the playground page
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground");

            // Step 2: Click "Drag & Drop Sliders"
            driver.FindElement(By.LinkText("Drag & Drop Sliders")).Click();

            // Step 3: Select the slider with "Default value 15"
            IWebElement slider = driver.FindElement(By.XPath("//input[@value='15']"));
            IWebElement sliderValue = driver.FindElement(By.Id("rangeSuccess"));
           
            // Step 4: Drag the slider to 95
            Actions action = new Actions(driver);
            action.ClickAndHold(slider).MoveByOffset(215, 0).Release().Perform();  // Adjust offset as needed

            // Step 5: Validate that the slider value shows 95
            Assert.AreEqual("95", sliderValue.Text, "Slider did not reach the expected value of 95!");
        }

        
    }
        
}
