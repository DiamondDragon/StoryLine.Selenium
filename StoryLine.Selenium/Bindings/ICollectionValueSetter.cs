using System.Collections.Generic;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Bindings
{
    public interface ICollectionValueSetter
    {
        object Set(object values, IEnumerable<IWebElement> elements, IWebDriver driver);
    }
}