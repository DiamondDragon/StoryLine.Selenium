using OpenQA.Selenium;

namespace StoryLine.Selenium.Setters
{
    public interface IValueSetter
    {
        void Set(object value, IWebElement element, IWebDriver driver);
    }
}