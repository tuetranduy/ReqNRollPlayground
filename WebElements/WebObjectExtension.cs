using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ReqnRollPlayground.Drivers;
using SeleniumExtras.WaitHelpers;
using System;

namespace ReqnRollPlayground.WebElements
{
    public static class WebObjectExtension
    {
        public static int GetWaitTimeoutSeconds()
        {
            return 60;
        }

        public static IWebElement WaitForElementToBeVisible(this WebObject webObject)
        {
            try
            {
                var wait = new WebDriverWait(BrowserFactory.GetWebDriver(), TimeSpan.FromSeconds(GetWaitTimeoutSeconds()));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

                return wait.Until(ExpectedConditions.ElementIsVisible(webObject.By));
            }
            catch (WebDriverTimeoutException exception)
            {
                throw exception;
            }
        }

        public static IWebElement WaitForElementToBeExisted(this WebObject webObject)
        {
            try
            {
                var wait = new WebDriverWait(BrowserFactory.GetWebDriver(), TimeSpan.FromSeconds(GetWaitTimeoutSeconds()));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                wait.Until(ExpectedConditions.ElementExists(webObject.By));

                return BrowserFactory.GetWebDriver().FindElement(webObject.By);
            }
            catch (WebDriverTimeoutException exception)
            {
                throw exception;
            }
        }

        public static void ClickOnElement(this WebObject webObject)
        {
            try
            {
                var element = webObject.WaitForElementToBeVisible();
                element.Click();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EnterText(this WebObject webObject, string text, bool bypassClearText = false)
        {
            try
            {
                var element = webObject.WaitForElementToBeVisible();
                element.Clear();
                element.SendKeys(text);
            }
            catch (WebDriverException)
            {
                throw;
            }
        }
    }
}