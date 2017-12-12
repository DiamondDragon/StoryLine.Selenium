using System.Collections.Generic;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Selectors
{
    public interface IElementSelector
    {
        IWebElement Find(ISearchContext element, IWebDriver driver);
        IEnumerable<IWebElement> FindAll(ISearchContext element, IWebDriver driver);
    }
}