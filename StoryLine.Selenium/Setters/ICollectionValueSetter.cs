using System.Collections.Generic;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Setters
{
    public interface ICollectionValueSetter
    {
        object Set(object values, IEnumerable<IWebElement> elements, IWebDriver driver);
    }
}