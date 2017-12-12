using OpenQA.Selenium;

namespace StoryLine.Selenium.Bindings
{
    public interface IValueSetter
    {
        void Set(object value, IWebElement element, IWebDriver driver);
    }
}