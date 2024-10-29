using OpenQA.Selenium;
using ReqnRollPlayground.WebElements;

namespace ReqnRollPlayground
{
    public class PageObject
    {
        private readonly WebObject _textArea = new WebObject(By.Id("textarea"));

        public PageObject() { }

        public void EnterTextArea(string text)
        {
            _textArea.EnterText(text);
        }
    }
}
