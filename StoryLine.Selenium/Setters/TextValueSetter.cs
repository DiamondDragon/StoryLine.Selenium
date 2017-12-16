using System;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Setters
{
    public class TextValueSetter : IValueSetter
    {
        public void Set(object value, IWebElement element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            if (value == null)
                return;

            element.Clear();
            element.SendKeys((string)Convert.ChangeType(value, typeof(string)));
        }
    }
}