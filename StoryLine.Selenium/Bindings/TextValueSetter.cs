using System;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Bindings
{
    public class TextValueSetter : IValueSetter
    {
        public void Set(object value, IWebElement element, IWebDriver driver)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            element.SendKeys((string)value);
        }
    }
}