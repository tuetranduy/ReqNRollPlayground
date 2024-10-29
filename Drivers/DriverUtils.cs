using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace ReqnRollPlayground.Drivers
{
    public class DriverUtils
    {
        public static void GoToUrl(string url, bool ignoreException = false)
        {
            try
            {
                BrowserFactory.GetWebDriver().Url = url;
            }
            catch (Exception ex)
            {
                if (ignoreException)
                {
                    Console.WriteLine("Page takes long time to load");
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        public static void ClearSessionData()
        {
            ((IJavaScriptExecutor)BrowserFactory.GetWebDriver()).ExecuteScript("sessionStorage.clear();");
            ((IJavaScriptExecutor)BrowserFactory.GetWebDriver()).ExecuteScript("localStorage.clear();");
        }

        public static string CaptureScreenshot(IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();

            return screenshot.AsBase64EncodedString;
        }

        public static string GetUrl()
        {
            return BrowserFactory.GetWebDriver().Url;
        }

        public static string GetPageSource()
        {
            return BrowserFactory.GetWebDriver().PageSource;
        }

        public static string GetCurrentWindowHandle()
        {
            return BrowserFactory.GetWebDriver().CurrentWindowHandle;
        }

        public static void SwitchWindow(string window)
        {
            BrowserFactory.GetWebDriver().SwitchTo().Window(window);
        }

        public static string SwitchWindow(int noOfCurrentWindows = 1)
        {
            //Store the ID of the original window
            string originalWindow = BrowserFactory.GetWebDriver().CurrentWindowHandle;

            //Wait for the new window or tab
            var wait = new WebDriverWait(BrowserFactory.GetWebDriver(), TimeSpan.FromSeconds(45));
            wait.Until(wd => wd.WindowHandles.Count == noOfCurrentWindows + 1);

            //Loop through until we find a new window handle
            foreach (string window in BrowserFactory.GetWebDriver().WindowHandles)
            {
                if (originalWindow != window)
                {
                    BrowserFactory.GetWebDriver().SwitchTo().Window(window);
                    return window;
                }
            }
            return null;
        }

        public static void SwitchWindow(ReadOnlyCollection<string> windows)
        {
            //Wait for the new window or tab
            var wait = new WebDriverWait(BrowserFactory.GetWebDriver(), TimeSpan.FromSeconds(45));
            wait.Until(wd => wd.WindowHandles.Count == windows.Count + 1);
            //Loop through until we find a new window handle
            foreach (string wd in BrowserFactory.GetWebDriver().WindowHandles)
            {
                if (!windows.Contains(wd))
                {
                    BrowserFactory.GetWebDriver().SwitchTo().Window(wd);
                }
            }
        }


        public static string SwitchWindowAndGetURL(string originalWindow, int noOfCurrentWindows = 1)
        {
            //Wait for the new window or tab
            var wait = new WebDriverWait(BrowserFactory.GetWebDriver(), TimeSpan.FromSeconds(45));
            wait.Until(wd => wd.WindowHandles.Count == noOfCurrentWindows + 1);

            //Loop through until we find a new window handle
            foreach (string window in BrowserFactory.GetWebDriver().WindowHandles)
            {
                if (originalWindow != window)
                {
                    BrowserFactory.GetWebDriver().SwitchTo().Window(window);
                    var url = BrowserFactory.GetWebDriver().Url;

                    BrowserFactory.GetWebDriver().Close();
                    return url;
                }
            }
            return null;
        }

        public static void CloseCurrentWindow(string originalWindowHandle)
        {
            BrowserFactory.GetWebDriver().Close();
            BrowserFactory.GetWebDriver().SwitchTo().Window(originalWindowHandle);
        }

        public static bool IsNewTabOpened(int noOfCurrentWindows = 1)
        {
            //Store the ID of the original window
            string originalWindow = BrowserFactory.GetWebDriver().CurrentWindowHandle;
            try
            {
                //Wait for the new window or tab
                var wait = new WebDriverWait(BrowserFactory.GetWebDriver(), TimeSpan.FromSeconds(45));
                wait.Until(wd => wd.WindowHandles.Count == noOfCurrentWindows + 1);
                BrowserFactory.GetWebDriver().SwitchTo().NewWindow(WindowType.Tab);
                BrowserFactory.GetWebDriver().Close();
                BrowserFactory.GetWebDriver().SwitchTo().Window(originalWindow);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ReloadPage()
        {
            BrowserFactory.GetWebDriver().Navigate().Refresh();
        }

        public static void BackPreviousPage()
        {
            BrowserFactory.GetWebDriver().Navigate().Back();
        }
    }
}
