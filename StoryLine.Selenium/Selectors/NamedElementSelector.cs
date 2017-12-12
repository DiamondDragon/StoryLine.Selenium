using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Selectors
{
    public class NamedElementSelector : IElementSelector
    {
        private readonly string _name;

        public NamedElementSelector(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public IWebElement Find(ISearchContext element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            return element.FindElement(By.Name(_name));
        }

        public IEnumerable<IWebElement> FindAll(ISearchContext element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            return element.FindElements(By.Name(_name));
        }
    }
}