using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SeleniumOnly
{
    public class SampleTest
    {
        [Fact]
        public void DisabledHeadless()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("--disable-extensions");
            options.AddArgument("--safebrowsing-disable-download-protection");
            options.AddArguments("no-sandbox");
            options.AddArgument("enable-automation");
            options.AddArgument("test-type=browser");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("safebrowsing", "enabled");
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            //options.AddArgument("--headless");

            var driver = new ChromeDriver(
                Directory.GetCurrentDirectory(),
                options,
                TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl("https://www.google.com");
        }


        [Fact]
        public void EnabledHeadless()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("--disable-extensions");
            options.AddArgument("--safebrowsing-disable-download-protection");
            options.AddArguments("no-sandbox");
            options.AddArgument("enable-automation");
            options.AddArgument("test-type=browser");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("safebrowsing", "enabled");
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            
            //Weird = Starting from V.93, without this argument, CHROME FAILS TO ENABLE
            options.AddArgument("--headless");

            var driver = new ChromeDriver(
                Directory.GetCurrentDirectory(),
                options,
                TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl("https://www.google.com");
        }
    }
}
