using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Selectors
{
    public class ByXPath : ElementSelectorBase
    {
        protected override string SelectorType => nameof(By.XPath);

        public ByXPath(string selector, string description = null)
            : base(selector, description)
        {
        }

        public override IWebElement Find(ISearchContext element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            return element.FindElement(By.XPath(Pattern));
        }

        public override IEnumerable<IWebElement> FindAll(ISearchContext element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            return element.FindElements(By.XPath(Pattern));
        }
    }
}