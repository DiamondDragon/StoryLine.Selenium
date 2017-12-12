using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Selectors
{
    public class CssElementSelector : IElementSelector
    {
        private readonly string _selector;

        public CssElementSelector(string selector)
        {
            _selector = selector ?? throw new ArgumentNullException(nameof(selector));
        }

        public IWebElement Find(ISearchContext element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            return element.FindElement(By.CssSelector(_selector));
        }

        public IEnumerable<IWebElement> FindAll(ISearchContext element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            return driver.FindElements(By.CssSelector(_selector));
        }
    }
}