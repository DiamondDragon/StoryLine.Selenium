using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Selectors
{
    public class TagNameElementSelector : ElementSelectorBase
    {
        protected override string SelectorType => nameof(By.TagName);

        public TagNameElementSelector(string tagName, string description = null)
            : base(tagName, description)
        {
        }

        public override IWebElement Find(ISearchContext element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            return element.FindElement(By.TagName(Pattern));
        }

        public override IEnumerable<IWebElement> FindAll(ISearchContext element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            return element.FindElements(By.TagName(Pattern));
        }
    }
}