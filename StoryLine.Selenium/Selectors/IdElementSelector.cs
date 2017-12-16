using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Selectors
{
    public class IdElementSelector : ElementSelectorBase
    {
        protected override string SelectorType => nameof(By.Id);

        public IdElementSelector(string id, string description = null)
            : base(id, description)
        {
        }

        public override IWebElement Find(ISearchContext element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            return element.FindElement(By.Id(Pattern));
        }

        public override IEnumerable<IWebElement> FindAll(ISearchContext element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            return element.FindElements(By.Id(Pattern));
        }
    }
}