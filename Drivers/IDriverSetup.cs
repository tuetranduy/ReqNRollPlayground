using OpenQA.Selenium;

namespace ReqnRollPlayground.Drivers
{
    public interface IDriverSetup
    {
        IWebDriver CreateInstance();
    }
}
