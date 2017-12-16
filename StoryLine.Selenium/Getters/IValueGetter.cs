using OpenQA.Selenium;

namespace StoryLine.Selenium.Getters
{
    public interface IValueGetter
    {
        object Get(IWebElement element, IWebDriver driver);
    }
}