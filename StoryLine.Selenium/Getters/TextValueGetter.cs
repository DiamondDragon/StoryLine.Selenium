using System;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Getters
{
    public class TextValueGetter : IValueGetter
    {
        public object Get(IWebElement element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            if (element.TagName.Equals("input", StringComparison.OrdinalIgnoreCase))
                return element.GetAttribute("value");

            return element.Text;
        }
    }
}