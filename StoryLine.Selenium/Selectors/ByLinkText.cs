using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Selectors
{
    public class ByLinkText : ElementSelectorBase
    {
        protected override string SelectorType => nameof(By.LinkText);

        public ByLinkText(string text, string description = null)
            : base(text, description)
        {
        }

        public override IWebElement Find(ISearchContext element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            return element.FindElement(By.LinkText(Pattern));
        }

        public override IEnumerable<IWebElement> FindAll(ISearchContext element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            return element.FindElements(By.LinkText(Pattern));
        }
    }
}