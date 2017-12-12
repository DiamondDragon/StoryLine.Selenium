using OpenQA.Selenium;

namespace StoryLine.Selenium.Bindings
{
    public interface IValueGetter
    {
        object Get(IWebElement element, IWebDriver driver);
    }
}