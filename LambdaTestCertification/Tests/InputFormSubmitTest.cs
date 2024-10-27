using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LambdaTestCertification.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    internal class InputFormSubmitTest : LambdaTestSetup
    {
        [Test, TestCase("Windows 10", "Chrome", "128.0")]
        [TestCase("macOS Ventura", "MicrosoftEdge", "127.0")]
        [TestCase("Windows 11", "Firefox", "130.0")]
        [TestCase("Windows 10", "Internet Explorer", "11.0")]
        public void InputFormSubmitValidation(string platform, string browser, string version)
        {
            // Initialize the driver with desired capabilities
            driver = InitializeDriver(platform, browser, version);

            // Step 1: Open the LambdaTest Selenium Playground
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/");
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000); // Consider replacing with WebDriverWait

            // Step 2: Click "Input Form Submit"
            IWebElement inputFormLink = driver.FindElement(By.XPath("//a[@href='https://www.lambdatest.com/selenium-playground/input-form-demo']"));
            inputFormLink.Click();

            // Step 3: Click Submit without filling in the form
            IWebElement submit = driver.FindElement(By.XPath("//div[@class='text-right mt-20']/button"));
            submit.Click();

            // Step 4: Assert validation message
            System.Threading.Thread.Sleep(1000); // Consider replacing with WebDriverWait
            IWebElement name = driver.FindElement(By.XPath("//div[@class='form-group w-4/12 smtablet:w-full text-section pr-20 smtablet:pr-0']/input[@type='text']"));
            string expectedValidation = name.GetAttribute("validationMessage");
            string actualValidation = "Please fill out this field.";
            Assert.AreEqual(actualValidation, expectedValidation, "Validation message does not match!");

            if (expectedValidation == actualValidation)
            {
                Console.WriteLine("Validation is properly appear.");
            }
            else
            {
                Console.WriteLine("Validation is not properly appear.");
            }

            // Step 5: Fill in the form fields
            name.SendKeys("TestName");

            IWebElement email = driver.FindElement(By.XPath("//div[@class='form-group w-4/12 smtablet:w-full text-section pr-20 smtablet:pr-0']/input[@type='email']"));
            email.SendKeys("Test123@gmail.com");

            IWebElement password = driver.FindElement(By.XPath("//div[@class='form-group w-4/12 smtablet:w-full']/input[@type='password']"));
            password.SendKeys("Test@1234");

            IWebElement company = driver.FindElement(By.XPath("//*[@id='company']"));
            company.SendKeys("TestCompany");

            IWebElement website = driver.FindElement(By.XPath("//div[@class='form-group w-6/12 smtablet:w-full']/input[@id='websitename']"));
            website.SendKeys("Testdomain.com");

            IWebElement country = driver.FindElement(By.XPath("//div[@class='form-group w-6/12 smtablet:w-full pr-20 smtablet:pr-0']/select[@name='country']"));
            SelectElement selectCountry = new SelectElement(country);
            selectCountry.SelectByText("United States");

            IWebElement city = driver.FindElement(By.XPath("//div[@class='form-group w-6/12 smtablet:w-full']/input[@id='inputCity']"));
            city.SendKeys("TestCity");

            IWebElement address1 = driver.FindElement(By.XPath("//div[@class='form-group w-6/12 smtablet:w-full pr-20 smtablet:pr-0']/input[@id='inputAddress1']"));
            address1.SendKeys("TestAddress1");

            IWebElement address2 = driver.FindElement(By.XPath("//div[@class='form-group w-6/12 smtablet:w-full']/input[@id='inputAddress2']"));
            address2.SendKeys("TestAddress2");

            IWebElement state = driver.FindElement(By.XPath("//div[@class='form-group w-6/12 smtablet:w-full pr-20 smtablet:pr-0']/input[@id='inputState']"));
            state.SendKeys("TestState");

            IWebElement zipcode = driver.FindElement(By.XPath("//div[@class='form-group w-6/12 smtablet:w-full']/input[@id='inputZip']"));
            zipcode.SendKeys("360002");

            // Step 6: Submit the form
            submit.Click();

            // Step 7: Validate the success message
            System.Threading.Thread.Sleep(2000); // Consider replacing with WebDriverWait
            IWebElement successMessage = driver.FindElement(By.XPath("//p[@class='success-msg hidden']"));
            string actualMessage = successMessage.Text;
            string expectedMessage = "Thanks for contacting us, we will get back to you shortly.";

            if (actualMessage.Equals(expectedMessage))
            {
                Console.WriteLine("Success message is properly appear.");
            }
            else
            {
                Console.WriteLine("Success message is not properly appear.");
            }

          
        }
    }
}
