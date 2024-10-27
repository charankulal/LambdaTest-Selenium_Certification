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

namespace LambdaTestCertification
{
    public class LambdaTestSetup
    {
        protected RemoteWebDriver driver;
        protected string Status = "passed";

        // Set up method without parameters
        [SetUp]
        public void Setup()
        {
            // Empty Setup; configurations are handled in each test
        }

        protected  RemoteWebDriver InitializeDriver(string platform, string browser, string version)
        {
            string username = Environment.GetEnvironmentVariable("LT_USERNAME") ?? "charan.kulal.02";
            string authkey = Environment.GetEnvironmentVariable("LT_ACCESS_KEY") ?? "IsTGp6fZGglj5clRCfwJCF7cDoLFfdjA7CWQmkbSR7CfEDTNsF";
            string hub = "@hub.lambdatest.com/wd/hub";

            var options = GetOptions(browser);
            options.PlatformName = platform;
            options.BrowserVersion = version;
            options.AddAdditionalOption("LT:Options", new
            {
                user = username,
                accessKey = authkey,
                build = "Selenium C# 101 Assignment",
                name = TestContext.CurrentContext.Test.Name,
                console = true,
                network = true,
                visual = true,
                video = true,
                timeout = 20
            });

            return new RemoteWebDriver(new Uri($"https://{username}:{authkey}{hub}"), options.ToCapabilities());
        }

        private dynamic GetOptions(string browser)
        {
            return browser switch
            {
                "Chrome" => new ChromeOptions(),
                "MicrosoftEdge" => new EdgeOptions(),
                "Firefox" => new FirefoxOptions(),
                "Internet Explorer" => new InternetExplorerOptions(),
                _ => throw new ArgumentException($"Browser '{browser}' is not supported.")
            };
        }

        [TearDown]
        public void TearDown()
        {
            driver?.ExecuteScript($"lambda-status={Status}");
            driver?.Quit();
        }
    }
}
