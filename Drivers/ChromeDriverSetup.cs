using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace ReqnRollPlayground.Drivers
{
    public class ChromeDriverSetup : IDriverSetup
    {
        public IWebDriver CreateInstance()
        {
            return new ChromeDriver(GetDriverOptions());
        }

        private ChromeOptions GetDriverOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("test-type --no-sandbox --start-maximized");
            chromeOptions.AddUserProfilePreference("autofill.credit_card_enabled", false);
            chromeOptions.SetLoggingPreference(LogType.Performance, LogLevel.All);

            var experimentalFlags = new List<string>
            {
                "enable-tls13-kyber@2",
            };
            chromeOptions.AddLocalStatePreference("browser.enabled_labs_experiments", experimentalFlags);

            return chromeOptions;
        }
    }
}
