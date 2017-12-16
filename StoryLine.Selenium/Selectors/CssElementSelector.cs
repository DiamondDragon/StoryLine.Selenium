using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Selectors
{
    public class CssElementSelector : ElementSelectorBase
    {
        protected override string SelectorType => nameof(By.CssSelector);

        public CssElementSelector(string pattern, string description = null)
            : base(pattern, description)
        {
        }

        public override IWebElement Find(ISearchContext element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            return element.FindElement(By.CssSelector(Pattern));
        }

        public override IEnumerable<IWebElement> FindAll(ISearchContext element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            return driver.FindElements(By.CssSelector(Pattern));
        }
    }
}