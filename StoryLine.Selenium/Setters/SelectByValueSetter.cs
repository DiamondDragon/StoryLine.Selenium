using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace StoryLine.Selenium.Setters
{
    public class SelectByValueSetter : IValueSetter
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
                select.SelectByValue((string)Convert.ChangeType(value, typeof(string)));
        }
    }
}