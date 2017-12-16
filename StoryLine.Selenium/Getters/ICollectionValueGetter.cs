using System.Collections.Generic;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Getters
{
    public interface ICollectionValueGetter
    {
        object Get(IEnumerable<IWebElement> elements, IWebDriver driver);
    }
}