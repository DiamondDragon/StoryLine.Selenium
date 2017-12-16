using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace StoryLine.Selenium.Setters
{
    public class SelectByIndexSetter : IValueSetter
    {
        public void Set(object value, IWebElement element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            var select = new SelectElement(element);

            if (value == null)
                select.DeselectAll();
            else
                select.SelectByIndex((int)Convert.ChangeType(value, typeof(int)));
        }
    }
}
